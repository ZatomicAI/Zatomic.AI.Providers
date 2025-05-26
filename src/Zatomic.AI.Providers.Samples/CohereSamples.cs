using System.Threading.Tasks;
using NUnit.Framework;
using Zatomic.AI.Providers.Cohere;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class CohereSamples : BaseSample
	{
		private readonly string _apiKey;
		private readonly string _model;

		public CohereSamples()
		{
			_apiKey = Configuration["Cohere:ApiKey"];
			_model = Configuration["Cohere:Model"];
		}

		[Test]
		public async Task Chat()
		{
			var client = new CohereChatClient(_apiKey);
			var request = new CohereChatRequest(_model);
			request.AddSystemMessage(SystemPrompt);
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(response.Message.Content[0].Text);
			WriteOutput(response.Usage.BilledUnits.InputTokens, response.Usage.BilledUnits.OutputTokens, response.Usage.BilledUnits.TotalTokens, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new CohereChatClient(_apiKey);
			var request = new CohereChatRequest(_model);
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
