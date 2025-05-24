using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatGroundingChunk
	{
		[JsonProperty("chunk_type")]
		[JsonConverter(typeof(GoogleGeminiChatChunkTypeConverter))]
		public GoogleGeminiChatBaseChunkType ChunkType { get; set; }
	}
}
