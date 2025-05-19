using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Hyperbolic
{
	public class HyperbolicChatChoice
	{
		[JsonProperty("delta")]
		public HyperbolicChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public HyperbolicChatMessage Message { get; set; }
	}
}
