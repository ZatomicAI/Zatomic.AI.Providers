using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatWebSearchOptions
	{
		[JsonProperty("search_context_size", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchContextSize { get; set; }

		[JsonProperty("user_location", NullValueHandling = NullValueHandling.Ignore)]
		public OpenAIChatUserLocation UserLocation { get; set; }
	}
}
