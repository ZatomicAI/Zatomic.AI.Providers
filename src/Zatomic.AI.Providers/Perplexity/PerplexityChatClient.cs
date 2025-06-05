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

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatClient : BaseClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.perplexity.ai/chat/completions";

		public PerplexityChatClient()
		{
		}

		public PerplexityChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<PerplexityChatResponse> ChatAsync(PerplexityChatRequest request)
		{
			PerplexityChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				var requestJson = request.Serialize();
				var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

				string responseJson = null;

				try
				{
					var stopwatch = Stopwatch.StartNew();

					var postResponse = await DoWithRetryAsync(() => httpClient.PostAsync(ApiUrl, content));
					responseJson = await postResponse.Content.ReadAsStringAsync();
					postResponse.EnsureSuccessStatusCode();

					stopwatch.Stop();

					response = responseJson.Deserialize<PerplexityChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildPerplexityAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResponse> ChatStreamAsync(PerplexityChatRequest request)
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
					postResponse = await DoWithRetryAsync(() => httpClient.SendAsync(postRequest, HttpCompletionOption.ResponseHeadersRead));
					postResponse.EnsureSuccessStatusCode();
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildPerplexityAIException(ex, request);
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
							var aiEx = AIExceptionUtility.BuildPerplexityAIException(ex, request);
							throw aiEx;
						}

						// Event messages start with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							var rsp = line.Substring(6).Deserialize<PerplexityChatResponse>();
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
