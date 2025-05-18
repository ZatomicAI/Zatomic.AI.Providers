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

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; set; } = "https://api.cohere.com/v2/chat";
		public string ClientName { get; set; }

		public CohereChatClient()
		{
		}

		public CohereChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<CohereChatResponse> ChatAsync(CohereChatRequest request)
		{
			CohereChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				if (!ClientName.IsNullOrEmpty())
				{
					httpClient.DefaultRequestHeaders.Add("X-Client-Name", ClientName);
				}

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

					response = responseJson.Deserialize<CohereChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildCohereAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(CohereChatRequest request)
		{
			request.Stream = true;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				if (!ClientName.IsNullOrEmpty())
				{
					httpClient.DefaultRequestHeaders.Add("X-Client-Name", ClientName);
				}

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
					var aiEx = AIExceptionUtility.BuildCohereAIException(ex, request);
					throw aiEx;
				}

				var streamComplete = false;
				var chunk = "";
				var inputTokens = 0;
				var outputTokens = 0;
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
							var aiEx = AIExceptionUtility.BuildCohereAIException(ex, request);
							throw aiEx;
						}

						// Cohere streams two types of lines: one that starts with "event:" and one that starts
						// with "data:". The "event:" lines basically tell you what kind of "data:" line is next,
						// but that bit of info is also in the "data:" line, so we only care about those.
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							if (line.Contains(CohereChatStreamEventTypes.ContentDelta))
							{
								var rsp = line.Substring(6).Deserialize<CohereChatStreamResponse>();
								chunk = rsp.Delta.Message.Content.Text;
							}

							if (line.Contains(CohereChatStreamEventTypes.MessageEnd))
							{
								var rsp = line.Substring(6).Deserialize<CohereChatStreamResponse>();
								inputTokens = rsp.Delta.Usage.Tokens.InputTokens;
								outputTokens = rsp.Delta.Usage.Tokens.OutputTokens;
								streamComplete = true;
								stopwatch.Stop();
							}

							var result = new AIStreamResult { Chunk = chunk };
							if (streamComplete)
							{
								result.InputTokens = inputTokens;
								result.OutputTokens = outputTokens;
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
