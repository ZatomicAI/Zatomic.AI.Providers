using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatReasoningText
	{
		[JsonProperty("signature", NullValueHandling = NullValueHandling.Ignore)]
		public string Signature { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
