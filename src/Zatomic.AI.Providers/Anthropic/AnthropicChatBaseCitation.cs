using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public abstract class AnthropicChatBaseCitation
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
