using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatResponse
	{
		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("output")]
		public AmazonBedrockChatOutput Output { get; set; }

		[JsonProperty("stop_reason")]
		public string StopReason { get; set; }

		[JsonProperty("usage")]
		public AmazonBedrockChatUsage Usage { get; set; }
	}
}
