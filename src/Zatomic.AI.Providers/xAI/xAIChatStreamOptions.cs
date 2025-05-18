using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
