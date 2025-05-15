using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicStreamContentBlockDelta
	{
		[JsonProperty("delta")]
		public AnthropicStreamDelta Delta { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
