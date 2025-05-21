using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatContentFilterSeverity
	{
		[JsonProperty("filtered")]
		public bool Filtered { get; set; }

		[JsonProperty("severity")]
		public string Severity { get; set; }
	}
}
