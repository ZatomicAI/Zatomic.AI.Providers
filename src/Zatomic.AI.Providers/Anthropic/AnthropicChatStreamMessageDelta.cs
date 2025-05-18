using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatStreamMessageDelta
	{
		[JsonProperty("delta")]
		public AnthropicChatStreamDelta Delta { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("usage")]
		public AnthropicChatUsage Usage { get; set; }
	}
}
