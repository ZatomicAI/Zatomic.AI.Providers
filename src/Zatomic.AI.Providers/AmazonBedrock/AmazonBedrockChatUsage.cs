using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatUsage
	{
		[JsonProperty("input_tokens")]
		public int InputTokens { get; set; }

		[JsonProperty("output_tokens")]
		public int OutputTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
