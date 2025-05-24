using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get; } = "https://api.llama.com/v1/chat/completions";

		public MetaChatClient()
		{
		}

		public MetaChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<MetaChatResponse> ChatAsync(MetaChatRequest request)
		{
			MetaChatResponse response = null;

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

					response = responseJson.Deserialize<MetaChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildMetaAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(MetaChatRequest request)
		{
			// Meta's Llama API doesn't yet support streaming, so we're simulating it with a basic hack
			// by splitting the non-stream response into words and spaces and using a 10ms sleep in between
			// returning chunks. When Meta supports streaming we'll update this method with a real implementation.

			var stopwatch = Stopwatch.StartNew();

			var result = await ChatAsync(request);

			var matches = Regex.Matches(result.CompletionMessage.Content[0].Text, @"\S+|\s+");
			foreach (Match match in matches)
			{
				Thread.Sleep(10);
				yield return new AIStreamResult { Chunk = match.Value };
			}

			stopwatch.Stop();

			yield return new AIStreamResult
			{
				InputTokens = result.Usage.PromptTokens,
				OutputTokens = result.Usage.CompletionTokens,
				TotalTokens = result.Usage.TotalTokens,
				Duration = stopwatch.ToDurationInSeconds(2)
			};
		}
	}
}
