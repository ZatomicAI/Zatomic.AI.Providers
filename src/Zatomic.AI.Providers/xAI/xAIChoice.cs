using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChoice
	{
		[JsonProperty("delta")]
		public xAIDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public xAIOutputMessage Message { get; set; }
	}
}
