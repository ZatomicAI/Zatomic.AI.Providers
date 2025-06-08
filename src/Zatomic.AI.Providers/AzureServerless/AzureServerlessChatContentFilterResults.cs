using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatContentFilterResults
	{
		[JsonProperty("hate")]
		public AzureServerlessChatContentFilterSeverity Hate { get; set; }

		[JsonProperty("self_harm")]
		public AzureServerlessChatContentFilterSeverity SelfHarm { get; set; }

		[JsonProperty("sexual")]
		public AzureServerlessChatContentFilterSeverity Sexual { get; set; }

		[JsonProperty("violence")]
		public AzureServerlessChatContentFilterSeverity Violence { get; set; }
	}
}
