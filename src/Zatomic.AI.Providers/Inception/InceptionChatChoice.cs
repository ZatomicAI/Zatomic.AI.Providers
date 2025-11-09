using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatChoice
	{
		[JsonProperty("delta")]
		public InceptionChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public InceptionChatOutputMessage Message { get; set; }
	}
}
