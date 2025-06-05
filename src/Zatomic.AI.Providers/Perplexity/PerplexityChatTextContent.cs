using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatTextContent : PerplexityChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
