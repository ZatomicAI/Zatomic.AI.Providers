using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatUrlMetadata
	{
		[JsonProperty("retrievedUrl")]
		public string RetrievedUrl { get; set; }

		[JsonProperty("urlRetrievalStatus")]
		public string UrlRetrievalStatus { get; set; }
	}
}
