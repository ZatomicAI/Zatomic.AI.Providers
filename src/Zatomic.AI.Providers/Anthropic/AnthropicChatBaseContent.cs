using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public abstract class AnthropicChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
