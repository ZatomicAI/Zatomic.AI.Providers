using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
