using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChoice
	{
		[JsonProperty("delta")]
		public TogetherAIDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public TogetherAIMessage Message { get; set; }
	}
}
