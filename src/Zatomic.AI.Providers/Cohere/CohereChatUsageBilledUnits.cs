using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatUsageBilledUnits
	{
		[JsonProperty("input_tokens")]
		public int InputTokens { get; set; }

		[JsonProperty("output_tokens")]
		public int OutputTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get { return InputTokens + OutputTokens; } }
	}
}
