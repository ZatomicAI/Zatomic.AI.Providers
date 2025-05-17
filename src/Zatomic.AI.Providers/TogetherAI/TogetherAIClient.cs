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

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; set; } = "https://api.together.xyz/v1/chat/completions";

		public TogetherAIClient()
		{
		}

		public TogetherAIClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<TogetherAIResponse> ChatAsync(TogetherAIRequest request)
		{
			TogetherAIResponse response = null;

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

					response = responseJson.Deserialize<TogetherAIResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildTogetherAIAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(TogetherAIRequest request)
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
					var aiEx = AIExceptionUtility.BuildTogetherAIAIException(ex, request);
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
							var aiEx = AIExceptionUtility.BuildTogetherAIAIException(ex, request);
							throw aiEx;
						}

						// Together AI streams event lines with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							var rsp = line.Substring(6).Deserialize<TogetherAIResponse>();
							var result = new AIStreamResult { Chunk = rsp.Choices[0].Delta.Content };

							if (!rsp.Choices[0].FinishReason.IsNullOrEmpty() && rsp.Choices[0].FinishReason == "stop")
							{
								streamComplete = true;
								stopwatch.Stop();

								if (rsp.Usage != null)
								{
									result.InputTokens = rsp.Usage.PromptTokens;
									result.OutputTokens = rsp.Usage.CompletionTokens;
									result.Duration = stopwatch.ToDurationInSeconds(2);
								}
							}

							yield return result;
						}
					}
				}
			}
		}
	}
}
