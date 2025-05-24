using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSemanticRetrieverChunk : GoogleGeminiChatBaseAttributionSource
	{
		[JsonProperty("chunk")]
		public string Chunk { get; set; }

		[JsonProperty("source")]
		public string Source { get; set; }
	}
}
