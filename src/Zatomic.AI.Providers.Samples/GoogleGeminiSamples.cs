using System.Threading.Tasks;
using NUnit.Framework;
using Zatomic.AI.Providers.GoogleGemini;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class GoogleGeminiSamples : BaseSample
	{
		private readonly string _apiKey;
		private readonly string _model;

		public GoogleGeminiSamples()
		{
			_apiKey = Configuration["GoogleGemini:ApiKey"];
			_model = Configuration["GoogleGemini:Model"];
		}

		[Test]
		public async Task Chat()
		{
			var client = new GoogleGeminiChatClient(_apiKey);
			var request = new GoogleGeminiChatRequest(_model);
			request.AddSystemMessage(SystemPrompt);
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(((GoogleGeminiChatTextPart)response.Candidates[0].Content.Parts[0]).Text);
			WriteOutput(response.UsageMetadata.PromptTokenCount, response.UsageMetadata.CandidatesTokenCount, response.UsageMetadata.TotalTokenCount, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new GoogleGeminiChatClient(_apiKey);
			var request = new GoogleGeminiChatRequest(_model);
			request.AddSystemMessage(SystemPrompt);
			request.AddUserMessage(UserPrompt);

			int inputTokens = 0;
			int outputTokens = 0;
			int totalTokens = 0;
			decimal duration = 0;

			await foreach (var result in client.ChatStreamAsync(request))
			{
				WriteOutput(result.Chunk);

				if (result.InputTokens.HasValue) inputTokens = result.InputTokens.Value;
				if (result.OutputTokens.HasValue) outputTokens = result.OutputTokens.Value;
				if (result.TotalTokens.HasValue) totalTokens = result.TotalTokens.Value;
				if (result.Duration.HasValue) duration = result.Duration.Value;
			}

			WriteOutput(inputTokens, outputTokens, totalTokens, duration);
		}
	}
}
