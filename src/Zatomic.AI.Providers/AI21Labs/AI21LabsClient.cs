using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; set; } = "https://api.ai21.com/studio/v1/chat/completions";

		public AI21LabsClient()
		{
		}

		public AI21LabsClient(string apiKey)
		{
			ApiKey = apiKey;
		}

		public async Task<AI21LabsResponse> ChatAsync(AI21LabsRequest request)
		{
			AI21LabsResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				var requestString = JsonConvert.SerializeObject(request);
				var content = new StringContent(requestString, Encoding.UTF8, "application/json");

				string responseString = null;

				try
				{
					var stopwatch = Stopwatch.StartNew();

					var postResponse = await httpClient.PostAsync(ApiUrl, content);
					responseString = await postResponse.Content.ReadAsStringAsync();
					postResponse.EnsureSuccessStatusCode();

					stopwatch.Stop();

					response = JsonConvert.DeserializeObject<AI21LabsResponse>(responseString);
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = BuildAIException(ex, request, responseString);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<StreamResult> ChatStreamAsync(AI21LabsRequest request)
		{
			// Stream-specific settings, N must be 1 when streaming
			request.Stream = true;
			request.N = 1;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				var postRequest = new HttpRequestMessage(HttpMethod.Post, ApiUrl)
				{
					Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
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
					var aiEx = BuildAIException(ex, request);
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
							var aiEx = BuildAIException(ex, request);
							throw aiEx;
						}

						if (!line.IsNullOrEmpty())
						{
							// Ignore everything before the first curly brace
							var index = line.IndexOf("{");
							if (index != -1)
							{
								line = line.Substring(index);
							}

							var rsp = JsonConvert.DeserializeObject<AI21LabsResponse>(line);
							if (!rsp.Choices[0].FinishReason.IsNullOrEmpty() && rsp.Choices[0].FinishReason == "stop")
							{
								streamComplete = true;
								stopwatch.Stop();
							}

							var result = new StreamResult { Chunk = rsp.Choices[0].Delta.Content };
							if (streamComplete)
							{
								result.InputTokens = rsp.Usage.PromptTokens;
								result.OutputTokens = rsp.Usage.CompletionTokens;
								result.Duration = stopwatch.ToDurationInSeconds(2);
							}

							yield return result;
						}
					}
				}
			}
		}

		private AIException BuildAIException(Exception ex, AI21LabsRequest request, string responseString = null)
		{
			// Clear the messages from the request to avoid data bloat
			// in the exception and any unwanted logging of messages
			request.Messages.Clear();

			var aiEx = new AIException(ex.Message)
			{
				Provider = "AI21 Labs",
				Request = JsonConvert.SerializeObject(request)
			};

			if (!responseString.IsNullOrEmpty())
			{
				aiEx.Response = responseString;
			}

			return aiEx;
		}
	}
}
