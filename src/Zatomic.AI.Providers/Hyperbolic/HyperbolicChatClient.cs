using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Hyperbolic
{
	public class HyperbolicChatClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.hyperbolic.xyz/v1/chat/completions";

		public HyperbolicChatClient()
		{
		}

		public HyperbolicChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<HyperbolicChatResponse> ChatAsync(HyperbolicChatRequest request)
		{
			HyperbolicChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				var requestJson = request.Serialize();
				var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

				string responseJson = null;

				try
				{
					var stopwatch = Stopwatch.StartNew();

					var postResponse = await httpClient.PostAsync(ApiUrl, content);
					responseJson = await postResponse.Content.ReadAsStringAsync();
					postResponse.EnsureSuccessStatusCode();
					
					stopwatch.Stop();

					response = responseJson.Deserialize<HyperbolicChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildHyperbolicAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(HyperbolicChatRequest request)
		{
			request.Stream = true;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				var requestJson = request.Serialize();
				var postRequest = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
				{
					Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
				};

				HttpResponseMessage postResponse = null;

				try
				{
					// This is wrapped in a try-catch in case an error occurs at the start
					postResponse = await httpClient.SendAsync(postRequest, HttpCompletionOption.ResponseHeadersRead);
					postResponse.EnsureSuccessStatusCode();
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildHyperbolicAIException(ex, request);
					throw aiEx;
				}

				var streamComplete = false;
				var stopwatch = Stopwatch.StartNew();

				using (var stream = await postResponse.Content.ReadAsStreamAsync())
				using (var reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream && !streamComplete)
					{
						string line;

						try
						{
							// This is wrapped in a try-catch in case an error occurs mid-stream
							line = await reader.ReadLineAsync();
						}
						catch (Exception ex)
						{
							var aiEx = AIExceptionUtility.BuildHyperbolicAIException(ex, request);
							throw aiEx;
						}

						// Event messages start with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							var result = new AIStreamResult();

							var rsp = line.Substring(6).Deserialize<HyperbolicChatResponse>();
							if (rsp.Choices.Count > 0)
							{
								result.Chunk = rsp.Choices[0].Delta.Content;
							}

							// Hyperbolic usage is only included in the chunk right before the final [DONE]
							// chunk (whereas all prior chunks won't have usage in them). This means that we can key
							// off that to determine if the stream is complete instead of looking at the finish reason.
							// The finish reason comes in the chunk just before the usage chunk, so if we keyed off
							// that we would never get the usage information.

							if (rsp.Usage != null)
							{
								streamComplete = true;
								stopwatch.Stop();

								result.InputTokens = rsp.Usage.PromptTokens;
								result.OutputTokens = rsp.Usage.CompletionTokens;
								result.TotalTokens = rsp.Usage.TotalTokens;
								result.Duration = stopwatch.ToDurationInSeconds(2);
							}

							yield return result;
						}
					}
				}
			}
		}
	}
}
