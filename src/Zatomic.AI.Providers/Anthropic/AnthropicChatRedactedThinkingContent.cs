using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatRedactedThinkingContent : AnthropicChatBaseContent
	{
		[JsonProperty("data")]
		public string Data { get; set; }
	}
}
