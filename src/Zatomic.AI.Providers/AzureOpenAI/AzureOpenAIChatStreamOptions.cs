using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
