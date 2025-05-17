using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
