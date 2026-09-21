using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatPromptFilterResult
	{
		[JsonProperty("prompt_index")]
		public int PromptIndex { get; set; }

		[JsonProperty("content_filter_results")]
		public MicrosoftFoundryChatContentFilterResults ContentFilterResults { get; set; }
	}
}
