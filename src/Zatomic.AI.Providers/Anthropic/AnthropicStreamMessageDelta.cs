using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicStreamMessageDelta
	{
		[JsonProperty("delta")]
		public AnthropicStreamDelta Delta { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("usage")]
		public AnthropicUsage Usage { get; set; }
	}
}
