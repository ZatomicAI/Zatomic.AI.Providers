using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatChoice
	{
		[JsonProperty("delta")]
		public xAIChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public xAIChatOutputMessage Message { get; set; }
	}
}
