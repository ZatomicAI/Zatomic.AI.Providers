using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatReasoningContent
	{
		[JsonProperty("reasoning_text", NullValueHandling = NullValueHandling.Ignore)]
		public AmazonBedrockChatReasoningText ReasoningText { get; set; }

		[JsonProperty("redacted_content", NullValueHandling = NullValueHandling.Ignore)]
		public string RedactedContent { get; set; }
	}
}
