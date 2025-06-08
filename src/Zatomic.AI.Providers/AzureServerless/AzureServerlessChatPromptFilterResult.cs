using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatPromptFilterResult
	{
		[JsonProperty("prompt_index")]
		public int PromptIndex { get; set; }

		[JsonProperty("content_filter_results")]
		public AzureServerlessChatContentFilterResults ContentFilterResults { get; set; }
	}
}
