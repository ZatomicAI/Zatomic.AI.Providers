using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatDelta
	{
		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("message")]
		public CohereChatDeltaMessage Message { get; set; }

		[JsonProperty("usage")]
		public CohereChatUsage Usage { get; set; }
	}
}
