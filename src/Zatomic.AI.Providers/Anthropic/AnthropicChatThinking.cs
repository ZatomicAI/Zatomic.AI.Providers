using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatThinking
	{
		[JsonProperty("budget_tokens")]
		public int BudgetTokens { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
