using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
