using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public abstract class PerplexityChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
