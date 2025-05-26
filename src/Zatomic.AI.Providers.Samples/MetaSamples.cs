using System.Threading.Tasks;
using NUnit.Framework;
using Zatomic.AI.Providers.Meta;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class MetaSamples : BaseSample
	{
		private readonly string _apiKey;
		private readonly string _model;

		public MetaSamples()
		{
			_apiKey = Configuration["Meta:ApiKey"];
			_model = Configuration["Meta:Model"];
		}

		[Test]
		public async Task Chat()
		{
			var client = new MetaChatClient(_apiKey);
			var request = new MetaChatRequest(_model);
			request.AddSystemMessage(SystemPrompt);
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(response.CompletionMessage.Content.Text);
			WriteOutput(response.Usage.PromptTokens, response.Usage.CompletionTokens, response.Usage.TotalTokens, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new MetaChatClient(_apiKey);
			var request = new MetaChatRequest(_model);
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
