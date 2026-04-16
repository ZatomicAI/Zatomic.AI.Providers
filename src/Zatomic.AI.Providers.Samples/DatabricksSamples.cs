using System.Threading.Tasks;
using NUnit.Framework;
using Zatomic.AI.Providers.Databricks;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class DatabricksSamples : BaseSample
	{
		private readonly string _apiKey;
		private readonly string _apiUrl;

		public DatabricksSamples()
		{
			_apiKey = Configuration["Databricks:ApiKey"];
			_apiUrl = Configuration["Databricks:ApiUrl"];
		}

		[Test]
		public async Task Chat()
		{
			var client = new DatabricksChatClient(_apiKey) { ApiUrl = _apiUrl, Timeout = Timeout };
			var request = new DatabricksChatRequest();
			request.AddSystemMessage(SystemPrompt);
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(response.Choices[0].Message.Content);
			WriteOutput(response.Usage.PromptTokens.Value, response.Usage.CompletionTokens.Value, response.Usage.TotalTokens.Value, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new DatabricksChatClient(_apiKey) { ApiUrl = _apiUrl, Timeout = Timeout };
			var request = new DatabricksChatRequest();
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
