using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatResponse
	{
		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("message")]
		public CohereChatOutputMessage Message { get; set; }

		[JsonProperty("usage")]
		public CohereChatUsage Usage { get; set; }
	}
}
