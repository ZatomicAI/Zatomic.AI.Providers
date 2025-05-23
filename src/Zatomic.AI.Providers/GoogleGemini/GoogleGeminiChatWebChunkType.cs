using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatWebChunkType : GoogleGeminiChatBaseChunkType
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }
	}
}
