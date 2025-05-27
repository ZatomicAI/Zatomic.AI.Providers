using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatClient : BaseClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.anthropic.com/v1/messages";
		public string ApiVersion { get; set; } = "2023-06-01";
		public List<string> BetaVersions { get; set; }

		public AnthropicChatClient()
		{
			BetaVersions = new List<string>();
		}

		public AnthropicChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<AnthropicChatResponse> ChatAsync(AnthropicChatRequest request)
		{
			AnthropicChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Anthropic-Version", ApiVersion);

				if (BetaVersions.Count > 0)
				{
					httpClient.DefaultRequestHeaders.Add("Anthropic-Beta", BetaVersions.ToDelimitedString(","));
				}

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

					response = responseJson.Deserialize<AnthropicChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildAnthropicAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(AnthropicChatRequest request)
		{
			request.Stream = true;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Anthropic-Version", ApiVersion);

				if (BetaVersions.Count > 0)
				{
					httpClient.DefaultRequestHeaders.Add("Anthropic-Beta", BetaVersions.ToDelimitedString(","));
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
					postResponse = await DoWithRetryAsync(() => httpClient.SendAsync(postRequest, HttpCompletionOption.ResponseHeadersRead));
					postResponse.EnsureSuccessStatusCode();
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildAnthropicAIException(ex, request);
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
							var aiEx = AIExceptionUtility.BuildAnthropicAIException(ex, request);
							throw aiEx;
						}

						// Event messages start with "data: ", so that's why we substring the line at 6
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							// First deserialize to just get the type of event
							var eventType = line.Substring(6).Deserialize<AnthropicChatStreamEventType>();

							// Then deserialize to the specific type of event
							if (eventType.Type == "message_start")
							{
								// Anthropic puts the input token count in the message start event
								var messageStart = line.Substring(6).Deserialize<AnthropicChatStreamMessageStart>();
								inputTokens = messageStart.Message.Usage.InputTokens;
							}
							else if (eventType.Type == "content_block_delta")
							{
								var delta = line.Substring(6).Deserialize<AnthropicChatStreamContentBlockDelta>();
								chunk = delta.Delta.Text;
							}
							else if (eventType.Type == "message_delta")
							{
								// Anthropic puts the output token count in the message delta event, which is right before the stop event
								var messageDelta = line.Substring(6).Deserialize<AnthropicChatStreamMessageDelta>();
								outputTokens = messageDelta.Usage.OutputTokens;
							}
							else if (eventType.Type == "message_stop")
							{
								streamComplete = true;
								stopwatch.Stop();
							}

							var result = new AIStreamResult { Chunk = chunk };
							if (streamComplete)
							{
								result.InputTokens = inputTokens;
								result.OutputTokens = outputTokens;
								result.TotalTokens = inputTokens + outputTokens;
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
