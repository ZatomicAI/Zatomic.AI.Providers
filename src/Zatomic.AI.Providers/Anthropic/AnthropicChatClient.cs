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
	public class AnthropicChatClient
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

					var postResponse = await httpClient.PostAsync(ApiUrl, content);
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
					postResponse = await httpClient.SendAsync(postRequest, HttpCompletionOption.ResponseHeadersRead);
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

						// Anthropic streams two types of lines: one that starts with "event:" and one that
						// starts with "data:". The "event:" lines basically tell you what kind of "data:" line
						// is next, but that bit of info is also in the "data:" line, so we only care about those.
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							if (line.Contains(AnthropicChatStreamEventTypes.MessageStart))
							{
								// Anthropic puts the input token count in the message start event
								var messageStart = line.Substring(6).Deserialize<AnthropicChatStreamMessageStart>();
								inputTokens = messageStart.Message.Usage.InputTokens;
							}

							if (line.Contains(AnthropicChatStreamEventTypes.MessageDelta))
							{
								// Anthropic puts the output token count in the message delta event
								var messageDelta = line.Substring(6).Deserialize<AnthropicChatStreamMessageDelta>();
								outputTokens = messageDelta.Usage.OutputTokens;
							}

							if (line.Contains(AnthropicChatStreamEventTypes.MessageStop))
							{
								streamComplete = true;
								stopwatch.Stop();
							}

							if (line.Contains(AnthropicChatStreamEventTypes.ContentBlockDelta))
							{
								var delta = line.Substring(6).Deserialize<AnthropicChatStreamContentBlockDelta>();
								chunk = delta.Delta.Text;
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
