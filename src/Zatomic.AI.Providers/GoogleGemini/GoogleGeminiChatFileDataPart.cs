using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatFileDataPart : GoogleGeminiChatBasePart
	{
		[JsonProperty("mimeType")]
		public string MimeType { get; set; }

		[JsonProperty("fileUri")]
		public string FileUri { get; set; }
	}
}
