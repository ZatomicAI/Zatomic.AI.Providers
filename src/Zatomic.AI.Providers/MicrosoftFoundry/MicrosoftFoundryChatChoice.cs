using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatChoice
	{
		[JsonProperty("content_filter_results")]
		public MicrosoftFoundryChatContentFilterResults ContentFilterResults { get; set; }

		[JsonProperty("delta")]
		public MicrosoftFoundryChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public MicrosoftFoundryChatOutputMessage Message { get; set; }
	}
}
