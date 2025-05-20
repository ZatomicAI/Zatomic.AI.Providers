using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatInlineDataPart : GoogleGeminiChatBasePart
	{
		[JsonProperty("mimeType")]
		public string MimeType { get; set; }

		[JsonProperty("data")]
		public string Data { get; set; }
	}
}
