using System.Threading.Tasks;
using NUnit.Framework;
using Zatomic.AI.Providers.AmazonBedrock;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class AmazonBedrockSamples : BaseSample
	{
		private readonly string _accessKey;
		private readonly string _secretKey;
		private readonly string _region;
		private readonly string _model;

		public AmazonBedrockSamples()
		{
			_accessKey = Configuration["AmazonBedrock:AccessKey"];
			_secretKey = Configuration["AmazonBedrock:SecretKey"];
			_region = Configuration["AmazonBedrock:Region"];
			_model = Configuration["AmazonBedrock:Model"];
		}

		[Test]
		public async Task Chat()
		{
			var client = new AmazonBedrockChatClient(_accessKey, _secretKey, _region);
			var request = new AmazonBedrockChatRequest(_model);
			request.System = SystemPrompt;
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(response.Output.Message.Content[0].Text);
			WriteOutput(response.Usage.InputTokens, response.Usage.OutputTokens, response.Usage.TotalTokens, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new AmazonBedrockChatClient(_accessKey, _secretKey, _region);
			var request = new AmazonBedrockChatRequest(_model);
			request.System = SystemPrompt;
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
