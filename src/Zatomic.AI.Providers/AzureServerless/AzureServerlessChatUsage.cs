using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatUsage
	{
		[JsonProperty("completion_tokens")]
		public int CompletionTokens { get; set; }

		[JsonProperty("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
