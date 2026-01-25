using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatClient : BaseClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.mistral.ai/v1/chat/completions";

		public MistralChatClient()
		{
		}

		public MistralChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<MistralChatResponse> ChatAsync(MistralChatRequest request)
		{
			MistralChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				if (Timeout.HasValue)
				{
					httpClient.Timeout = TimeSpan.FromSeconds(Timeout.Value);
				}

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

					response = responseJson.Deserialize<MistralChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildMistralAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResponse> ChatStreamAsync(MistralChatRequest request)
		{
			request.Stream = true;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				if (Timeout.HasValue)
				{
					httpClient.Timeout = TimeSpan.FromSeconds(Timeout.Value);
				}

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
					var aiEx = AIExceptionUtility.BuildMistralAIException(ex, request);
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
							var aiEx = AIExceptionUtility.BuildMistralAIException(ex, request);
							throw aiEx;
						}

						// Check for end of stream
						if (line == null) break;

						// Event messages start with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							var rsp = line.Substring(6).Deserialize<MistralChatResponse>();
							var streamResponse = new AIStreamResponse { Chunk = rsp.Choices[0].Delta.Content };

							if (!rsp.Choices[0].FinishReason.IsNullOrEmpty())
							{
								streamComplete = true;
								stopwatch.Stop();
								streamResponse.Duration = stopwatch.ToDurationInSeconds(2);

								if (rsp.Usage != null)
								{
									streamResponse.InputTokens = rsp.Usage.PromptTokens;
									streamResponse.OutputTokens = rsp.Usage.CompletionTokens;
									streamResponse.TotalTokens = rsp.Usage.TotalTokens;
								}
							}

							yield return streamResponse;
						}
					}
				}
			}
		}
	}
}
