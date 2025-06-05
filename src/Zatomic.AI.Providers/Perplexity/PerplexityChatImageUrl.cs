using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
