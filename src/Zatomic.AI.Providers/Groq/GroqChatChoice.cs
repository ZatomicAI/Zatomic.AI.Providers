using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatChoice
	{
		[JsonProperty("delta")]
		public GroqChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public GroqChatOutputMessage Message { get; set; }
	}
}
