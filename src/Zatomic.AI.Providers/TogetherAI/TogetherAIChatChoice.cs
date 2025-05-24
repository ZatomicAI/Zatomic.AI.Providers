using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatChoice
	{
		[JsonProperty("delta")]
		public TogetherAIChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public TogetherAIChatOutputMessage Message { get; set; }

		[JsonProperty("seed")]
		public long Seed { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
