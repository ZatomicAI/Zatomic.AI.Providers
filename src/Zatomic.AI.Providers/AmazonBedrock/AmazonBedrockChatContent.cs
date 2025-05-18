using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatContent
	{
		[JsonProperty("reasoning_content", NullValueHandling = NullValueHandling.Ignore)]
		public AmazonBedrockChatReasoningContent ReasoningContent { get; set; }

		[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
		public string Text { get; set; }
	}
}
