using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatImageUrlContent : PerplexityChatBaseContent
	{
		[JsonProperty("image_url")]
		public PerplexityChatImageUrl ImageUrl { get; set; }
	}
}
