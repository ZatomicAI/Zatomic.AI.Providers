using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatChoice
	{
		[JsonProperty("delta")]
		public IbmWatsonXChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public IbmWatsonXChatOutputMessage Message { get; set; }
	}
}
