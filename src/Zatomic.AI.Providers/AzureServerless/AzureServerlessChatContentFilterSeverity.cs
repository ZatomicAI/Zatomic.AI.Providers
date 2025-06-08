using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatContentFilterSeverity
	{
		[JsonProperty("filtered")]
		public bool Filtered { get; set; }

		[JsonProperty("severity")]
		public string Severity { get; set; }
	}
}
