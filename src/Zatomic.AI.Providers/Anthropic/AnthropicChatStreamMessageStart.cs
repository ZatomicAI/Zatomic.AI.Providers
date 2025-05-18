using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatStreamMessageStart
	{
		[JsonProperty("message")]
		public AnthropicChatResponse Message { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
