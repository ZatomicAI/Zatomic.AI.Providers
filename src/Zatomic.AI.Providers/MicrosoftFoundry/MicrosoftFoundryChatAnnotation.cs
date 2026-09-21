using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatAnnotation
	{
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("url_citation")]
		public MicrosoftFoundryChatUrlCitation UrlCitation { get; set; }
	}
}
