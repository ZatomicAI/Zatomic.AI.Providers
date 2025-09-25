using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatClient : BaseClient
	{
		public string ApiKey { get; set; }

		public GoogleGeminiChatClient()
		{
		}

		public GoogleGeminiChatClient(string apiKey) : this()
		{
			ApiKey = apiKey;
		}

		public async Task<GoogleGeminiChatResponse> ChatAsync(GoogleGeminiChatRequest request)
		{
			var apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/{request.Model}:generateContent?key={ApiKey}";

			GoogleGeminiChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				var requestJson = request.Serialize();
				var content = new StringContent(requestJson, new MediaTypeHeaderValue("application/json"));

				var responseJson = "";

				try
				{
					var stopwatch = Stopwatch.StartNew();

					var postResponse = await DoWithRetryAsync(() => httpClient.PostAsync(apiUrl, content));
					responseJson = await postResponse.Content.ReadAsStringAsync();
					postResponse.EnsureSuccessStatusCode();

					stopwatch.Stop();

					response = responseJson.Deserialize<GoogleGeminiChatResponse>();
					response.Duration = stopwatch.ToDurationInSeconds(2);
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildGoogleGeminiAIException(ex, request, responseJson);
					throw aiEx;
				}
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResponse> ChatStreamAsync(GoogleGeminiChatRequest request)
		{
			// Google didn't implement streaming they way everyone else did with sever-side events (SSE). Instead, what they
			// did for their streaming endpoint was basically return the entire response as if it was for the non-streaming
			// endpoint, but broken up into chunks. And instead of the response containing one response object it essentially
			// contains a list of response objects. Not only that, their chunks are much bigger (i.e. full sentences) than the
			// normal one or two word chunks that other AI providers return. They took a very lazy way out. So, there is no
			// actual streaming Google Gemini. To get around this, we're simulating it by calling the non-streaming endpoint
			// and splitting the response into words and spaces and using a 10ms sleep in between returning chunks. If Google
			// ever properly implements their streaming endpoint with SSE, then we'll update this accordingly.
			// 
			// For reference, here are the two endpoints:
			//
			// https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={api-key}
			// https://generativelanguage.googleapis.com/v1beta/models/{model}:streamGenerateContent?key={api-key}

			var stopwatch = Stopwatch.StartNew();

			var result = await ChatAsync(request);

			var matches = Regex.Matches(((GoogleGeminiChatTextPart)result.Candidates[0].Content.Parts[0]).Text, @"\S+|\s+");
			foreach (Match match in matches)
			{
				await Task.Delay(10);
				yield return new AIStreamResponse { Chunk = match.Value };
			}

			stopwatch.Stop();

			yield return new AIStreamResponse
			{
				InputTokens = result.UsageMetadata.PromptTokenCount,
				OutputTokens = result.UsageMetadata.CandidatesTokenCount,
				TotalTokens = result.UsageMetadata.TotalTokenCount,
				Duration = stopwatch.ToDurationInSeconds(2)
			};
		}
	}
}
