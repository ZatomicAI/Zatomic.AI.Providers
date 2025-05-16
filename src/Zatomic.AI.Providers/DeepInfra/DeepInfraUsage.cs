using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraUsage
	{
		[JsonProperty("completion_tokens")]
		public int CompletionTokens { get; set; }

		[JsonProperty("estimated_cost")]
		public decimal EstimatedCost { get; set; }

		[JsonProperty("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
