using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatChoice
	{
		[JsonProperty("content_filter_results")]
		public AzureServerlessChatContentFilterResults ContentFilterResults { get; set; }

		[JsonProperty("delta")]
		public AzureServerlessChatDelta Delta { get; set; }
		
		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public AzureServerlessChatOutputMessage Message { get; set; }
	}
}
