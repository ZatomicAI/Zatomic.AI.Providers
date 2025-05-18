using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatStreamDelta
	{
		[JsonProperty("message")]
		public CohereChatStreamMessage Message { get; set; }

		[JsonProperty("usage")]
		public CohereChatUsage Usage { get; set; }
	}
}
