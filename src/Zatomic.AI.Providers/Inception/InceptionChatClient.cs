using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatClient : BaseClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.inceptionlabs.ai/v1/chat/completions";

		public InceptionChatClient()
		{
		}

		public InceptionChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<InceptionChatResponse> ChatAsync(InceptionChatRequest request)
		{
			InceptionChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				string responseJson = null;

				try
				{
					var stopwatch = Stopwatch.StartNew();

					using var postResponse = await DoWithRetryAsync(() =>
					{
						var requestJson = request.Serialize();
						var content = new StringContent(requestJson, new MediaTypeHeaderValue("application/json"));
						return httpClient.PostAsync(ApiUrl, content);
					});

					responseJson = await postResponse.Content.ReadAsStringAsync();
					postResponse.EnsureSuccessStatusCode();

					stopwatch.Stop();

					response = responseJson.Deserialize<InceptionChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildInceptionAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResponse> ChatStreamAsync(InceptionChatRequest request)
		{
			request.Stream = true;
			request.StreamOptions = new InceptionChatStreamOptions { IncludeUsage = true };

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				HttpResponseMessage postResponse = null;

				try
				{
					// This is wrapped in a try-catch in case an error occurs at the start
					postResponse = await DoWithRetryAsync(() =>
					{
						var requestJson = request.Serialize();
						var req = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
						{
							Content = new StringContent(requestJson, new MediaTypeHeaderValue("application/json"))
						};

						return httpClient.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);
					});

					postResponse.EnsureSuccessStatusCode();
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildInceptionAIException(ex, request);
					throw aiEx;
				}

				var streamComplete = false;
				var stopwatch = Stopwatch.StartNew();

				using (var stream = await postResponse.Content.ReadAsStreamAsync())
				using (var reader = new StreamReader(stream))
				{
					while (!streamComplete)
					{
						string line;

						try
						{
							// This is wrapped in a try-catch in case an error occurs mid-stream
							line = await reader.ReadLineAsync();
						}
						catch (Exception ex)
						{
							var aiEx = AIExceptionUtility.BuildInceptionAIException(ex, request);
							throw aiEx;
						}

						// Check for end of stream
						if (line == null) break;

						// Event messages start with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							var streamResponse = new AIStreamResponse();

							var rsp = line.Substring(6).Deserialize<InceptionChatResponse>();
							if (rsp.Choices.Count > 0)
							{
								streamResponse.Chunk = rsp.Choices[0].Delta.Content;
							}

							// Using Inception's stream options to include usage means that they return an additional chunk
							// with the usage information right before the final [DONE] chunk (whereas all prior chunks
							// won't have usage in them). This means that we can key off that to determine if the stream
							// is complete instead of looking at the finish reason. The finish reason comes in the chunk
							// just before the usage chunk, so if we keyed off that we would never get the usage information.

							if (rsp.Usage != null)
							{
								streamComplete = true;
								stopwatch.Stop();

								streamResponse.InputTokens = rsp.Usage.PromptTokens;
								streamResponse.OutputTokens = rsp.Usage.CompletionTokens;
								streamResponse.TotalTokens = rsp.Usage.TotalTokens;
								streamResponse.Duration = stopwatch.ToDurationInSeconds(2);
							}

							yield return streamResponse;
						}
					}
				}
			}
		}
	}
}
