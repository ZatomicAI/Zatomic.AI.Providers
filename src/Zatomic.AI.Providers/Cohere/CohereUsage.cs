using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereUsage
	{
		[JsonProperty("billed_units")]
		public CohereUsageBilledUnits BilledUnits { get; set; }

		[JsonProperty("tokens")]
		public CohereUsageTokens Tokens { get; set; }
	}
}
