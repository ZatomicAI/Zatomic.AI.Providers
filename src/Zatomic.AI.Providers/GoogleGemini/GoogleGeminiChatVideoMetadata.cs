using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatVideoMetadata : GoogleGeminiChatBaseMetadata
	{
		[JsonProperty("endOffset")]
		public string EndOffset { get; set; }

		[JsonProperty("fps")]
		public float FramesPerSecond { get; set; }

		[JsonProperty("startOffset")]
		public string StartOffset { get; set; }
	}
}
