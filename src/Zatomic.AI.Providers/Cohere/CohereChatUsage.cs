using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatUsage
	{
		[JsonProperty("billed_units")]
		public CohereChatUsageBilledUnits BilledUnits { get; set; }

		[JsonProperty("tokens")]
		public CohereChatUsageTokens Tokens { get; set; }
	}
}
