using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Zatomic.AI.Providers.Anthropic;

namespace Zatomic.AI.Providers.Samples
{
	[TestFixture, Explicit]
	public class AnthropicSamples : BaseSample
	{
		private readonly string _apiKey;
		private readonly string _model;
		private readonly int _maxTokens;

		public AnthropicSamples()
		{
			_apiKey = Configuration["Anthropic:ApiKey"];
			_model = Configuration["Anthropic:Model"];
			_maxTokens = Convert.ToInt32(Configuration["Anthropic:MaxTokens"]);
		}

		[Test]
		public async Task Chat()
		{
			var client = new AnthropicChatClient(_apiKey);
			var request = new AnthropicChatRequest(_model, _maxTokens);
			request.System = SystemPrompt;
			request.AddUserMessage(UserPrompt);

			var response = await client.ChatAsync(request);
			WriteOutput(((AnthropicChatTextContent)response.Content[0]).Text);
			WriteOutput(response.Usage.InputTokens, response.Usage.OutputTokens, response.Usage.TotalTokens, response.Duration.Value);
		}

		[Test]
		public async Task ChatStream()
		{
			var client = new AnthropicChatClient(_apiKey);
			var request = new AnthropicChatRequest(_model, _maxTokens);
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
