using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; set; } = "https://api.anthropic.com/v1/messages";
		public string ApiVersion { get; set; } = "2023-06-01";
		public List<string> BetaVersions { get; private set; }

		public AnthropicClient()
		{
			BetaVersions = new List<string>();
		}

		public AnthropicClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<AnthropicResponse> ChatAsync(AnthropicRequest request)
		{
			AnthropicResponse response = null;

			using (var httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Anthropic-Version", ApiVersion);

				if (BetaVersions.Count > 0)
				{
					httpClient.DefaultRequestHeaders.Add("Anthropic-Beta", BetaVersions.ToDelimitedString(","));
				}

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

					response = JsonConvert.DeserializeObject<AnthropicResponse>(responseString);
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

		public async IAsyncEnumerable<StreamResult> ChatStreamAsync(AnthropicRequest request)
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
							var aiEx = BuildAIException(ex, request);
							throw aiEx;
						}

						// Anthropic streams two types of lines: one that starts with "event:" and one that
						// starts with "data:". The "event:" lines basically tell you what kind of "data:" line
						// is next, but that bit of info is also in the "data:" line, so we only care about those.
						if (!line.IsNullOrEmpty() && line.StartsWith("data: "))
						{
							if (line.Contains(AnthropicStreamEventTypes.MessageStart))
							{
								// Anthropic puts the input token count in the message start event
								var messageStart = JsonConvert.DeserializeObject<AnthropicStreamMessageStart>(line.Substring(6));
								inputTokens = messageStart.Message.Usage.InputTokens;
							}

							if (line.Contains(AnthropicStreamEventTypes.MessageDelta))
							{
								// Anthropic puts the output token count in the message delta event
								var messageDelta = JsonConvert.DeserializeObject<AnthropicStreamMessageDelta>(line.Substring(6));
								outputTokens = messageDelta.Usage.OutputTokens;
							}

							if (line.Contains(AnthropicStreamEventTypes.MessageStop))
							{
								streamComplete = true;
								stopwatch.Stop();
							}

							if (line.Contains(AnthropicStreamEventTypes.ContentBlockDelta))
							{
								var delta = JsonConvert.DeserializeObject<AnthropicStreamContentBlockDelta>(line.Substring(6));
								chunk = delta.Delta.Text;
							}

							var result = new StreamResult { Chunk = chunk };
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

		private AIException BuildAIException(Exception ex, AnthropicRequest request, string responseString = null)
		{
			// Clear the messages from the request to avoid data bloat
			// in the exception and any unwanted logging of messages
			request.Messages.Clear();

			var aiEx = new AIException(ex.Message)
			{
				Provider = "Anthropic",
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
