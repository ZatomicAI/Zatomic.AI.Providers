using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatStreamEventType
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
