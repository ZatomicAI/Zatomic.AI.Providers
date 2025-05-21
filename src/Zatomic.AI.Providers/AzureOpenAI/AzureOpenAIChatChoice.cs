using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatChoice
	{
		[JsonProperty("content_filter_results")]
		public AzureOpenAIChatContentFilterResults ContentFilterResults { get; set; }

		[JsonProperty("delta")]
		public AzureOpenAIChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public AzureOpenAIChatOutputMessage Message { get; set; }
	}
}
