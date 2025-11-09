using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
