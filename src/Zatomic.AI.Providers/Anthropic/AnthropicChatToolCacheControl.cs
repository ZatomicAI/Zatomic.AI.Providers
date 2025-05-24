using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatToolCacheControl
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
