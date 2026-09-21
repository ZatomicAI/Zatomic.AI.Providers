using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatContentFilterSeverity
	{
		[JsonProperty("filtered")]
		public bool Filtered { get; set; }

		[JsonProperty("severity")]
		public string Severity { get; set; }
	}
}
