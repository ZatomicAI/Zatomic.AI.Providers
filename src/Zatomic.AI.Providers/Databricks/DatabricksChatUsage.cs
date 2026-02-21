using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatUsage
	{
		[JsonProperty("completion_tokens")]
		public int? CompletionTokens { get; set; }

		[JsonProperty("prompt_tokens")]
		public int? PromptTokens { get; set; }

		[JsonProperty("reasoning_tokens")]
		public int? ReasoningTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int? TotalTokens { get; set; }
	}
}
