using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatAnnotation
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("url_citation")]
		public AzureOpenAIChatUrlCitation UrlCitation { get; set; }
	}
}
