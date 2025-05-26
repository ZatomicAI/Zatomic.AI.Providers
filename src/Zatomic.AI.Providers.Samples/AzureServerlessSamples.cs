using NUnit.Framework;
using System.Threading.Tasks;
using Zatomic.AI.Providers.AzureServerless;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class AzureServerlessSamples : BaseSample
	{
		private readonly string _apiKey;
		private readonly string _endpoint;
		private readonly string _modelName;

		public AzureServerlessSamples()
		{
			_apiKey = Configuration["AzureServerless:ApiKey"];
			_endpoint = Configuration["AzureServerless:Endpoint"];
			_modelName = Configuration["AzureServerless:ModelName"];
		}

		[Test]
		public async Task Chat()
		{
			var client = new AzureServerlessChatClient(_endpoint, _apiKey)
			{
				Endpoint = _endpoint
			};

			var request = new AzureServerlessChatRequest(_modelName);
			request.AddSystemMessage(SystemPrompt);
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(response.Choices[0].Message.Content);
			WriteOutput(response.Usage.PromptTokens, response.Usage.CompletionTokens, response.Usage.TotalTokens, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new AzureServerlessChatClient(_endpoint, _apiKey)
			{
				Endpoint = _endpoint
			};

			var request = new AzureServerlessChatRequest(_modelName);
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
