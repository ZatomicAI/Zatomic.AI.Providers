using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicThinkingContent : BaseAnthropicContent
	{
		[JsonProperty("signature")]
		public string Signature { get; set; }

		[JsonProperty("thinking")]
		public string Thinking { get; set; }
	}
}
