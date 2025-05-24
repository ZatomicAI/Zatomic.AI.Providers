using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatPromptFilterResult
	{
		[JsonProperty("prompt_index")]
		public int PromptIndex { get; set; }

		[JsonProperty("content_filter_results")]
		public AzureOpenAIChatContentFilterResults ContentFilterResults { get; set; }
	}
}
