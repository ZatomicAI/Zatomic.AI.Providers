using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicStreamDelta
	{
		[JsonProperty("stop_reason")]
		public string StopReason { get; set; }

		[JsonProperty("stop_sequence")]
		public string StopSequence { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
