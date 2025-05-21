using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatAnnotation
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("url_citation")]
		public OpenAIChatUrlCitation UrlCitation { get; set; }
	}
}
