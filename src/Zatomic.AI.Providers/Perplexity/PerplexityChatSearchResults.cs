using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatSearchResults
	{
		[JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
		public string Date { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
