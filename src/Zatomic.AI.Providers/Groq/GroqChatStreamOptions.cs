using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatStreamOptions
	{
		[JsonProperty("include_usage")]
		public bool IncludeUsage { get; set; }
	}
}
