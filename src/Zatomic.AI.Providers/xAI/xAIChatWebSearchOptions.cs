using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatWebSearchOptions
	{
		[JsonProperty("search_context_size", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchContextSize { get; set; }
	}
}
