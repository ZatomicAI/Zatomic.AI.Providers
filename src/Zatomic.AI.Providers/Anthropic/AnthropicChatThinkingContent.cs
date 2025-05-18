using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatThinkingContent : AnthropicChatBaseContent
	{
		[JsonProperty("signature")]
		public string Signature { get; set; }

		[JsonProperty("thinking")]
		public string Thinking { get; set; }
	}
}
