using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatRetrievalMetadata
	{
		[JsonProperty("googleSearchDynamicRetrievalScore")]
		public float SearchDynamicRetrievalScore { get; set; }
	}
}
