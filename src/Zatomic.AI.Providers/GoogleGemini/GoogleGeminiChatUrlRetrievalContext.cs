using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatUrlRetrievalContext
	{
		[JsonProperty("retrievedUrl")]
		public string RetrievedUrl { get; set; }
	}
}
