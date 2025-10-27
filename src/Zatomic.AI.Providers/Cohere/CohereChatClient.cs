using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatClient : BaseClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.cohere.com/v2/chat";
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

		public async IAsyncEnumerable<AIStreamResponse> ChatStreamAsync(CohereChatRequest request)
		{
			request.Stream = true;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);

				if (!ClientName.IsNullOrEmpty())
				{
					httpClient.DefaultRequestHeaders.Add("X-Client-Name", ClientName);
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

						// Event messages start with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							// First deserialize to just get the type of event
							var eventType = line.Substring(6).Deserialize<CohereChatStreamEventType>();

							// Then deserialize to the specific type of event
							if (eventType.Type == "content-delta")
							{
								var contentDelta = line.Substring(6).Deserialize<CohereChatStreamContentDelta>();
								chunk = contentDelta.Delta.Message.Content.Text;
							}
							else if (eventType.Type == "message-end")
							{
								var messageEnd = line.Substring(6).Deserialize<CohereChatStreamMessageEnd>();
								inputTokens = messageEnd.Delta.Usage.BilledUnits.InputTokens;
								outputTokens = messageEnd.Delta.Usage.BilledUnits.OutputTokens;
								streamComplete = true;
								stopwatch.Stop();
							}

							var streamResponse = new AIStreamResponse { Chunk = chunk };
							if (streamComplete)
							{
								streamResponse.InputTokens = inputTokens;
								streamResponse.OutputTokens = outputTokens;
								streamResponse.TotalTokens = inputTokens + outputTokens;
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
