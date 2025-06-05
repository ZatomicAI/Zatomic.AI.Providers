using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatWebSearchOptions
	{
		[JsonProperty("search_context_size", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchContextSize { get; set; }

		[JsonProperty("user_location", NullValueHandling = NullValueHandling.Ignore)]
		public PerplexityChatUserLocation UserLocation { get; set; }
	}
}
