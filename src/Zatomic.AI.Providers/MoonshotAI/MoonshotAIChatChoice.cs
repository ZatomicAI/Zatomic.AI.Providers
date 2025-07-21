using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatChoice
	{
		[JsonProperty("delta")]
		public MoonshotAIChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public MoonshotAIChatOutputMessage Message { get; set; }

		[JsonProperty("usage")]
		public MoonshotAIChatUsage Usage { get; set; }
	}
}
