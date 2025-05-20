using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatClient
	{
		public string ApiKey { get; set; }
		public string ApiUrl { get { return $"https://generativelanguage.googleapis.com/v1beta/models/{Model}:generateContent?key={ApiKey}"; } }
		public string Model { get; set; }

		public GoogleGeminiChatClient()
		{
		}

		public GoogleGeminiChatClient(string model, string apiKey) : this()
		{
			Model = model;
			ApiKey = apiKey;
		}

		public async Task<GoogleGeminiChatResponse> ChatAsync(GoogleGeminiChatRequest request)
		{
			GoogleGeminiChatResponse response = null;

			using (var httpClient = new HttpClient())
			{
				var requestJson = request.Serialize();
				var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

				var responseJson = "";

				try
				{
					var stopwatch = Stopwatch.StartNew();

					var postResponse = await httpClient.PostAsync(ApiUrl, content);
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

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(GoogleGeminiChatRequest request)
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
			// https://generativelanguage.googleapis.com/v1beta/models/{Model}:generateContent?key={ApiKey}
			// https://generativelanguage.googleapis.com/v1beta/models/{Model}:streamGenerateContent?key={ApiKey}

			var stopwatch = Stopwatch.StartNew();

			var result = await ChatAsync(request);

			var matches = Regex.Matches(((GoogleGeminiChatTextPart)result.Candidates[0].Content.Parts[0]).Text, @"\S+|\s+");
			foreach (Match match in matches)
			{
				Thread.Sleep(10);
				yield return new AIStreamResult { Chunk = match.Value };
			}

			stopwatch.Stop();

			yield return new AIStreamResult
			{
				InputTokens = result.UsageMetadata.PromptTokenCount,
				OutputTokens = result.UsageMetadata.CandidatesTokenCount,
				TotalTokens = result.UsageMetadata.TotalTokenCount,
				Duration = stopwatch.ToDurationInSeconds(2)
			};
		}
	}
}
