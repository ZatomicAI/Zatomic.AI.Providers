using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSearchRetrieval
	{
		[JsonProperty("dynamicRetrievalConfig")]
		public GoogleGeminiChatDynamicRetrievalConfig DynamicRetrievalConfig { get; set; }
	}
}
