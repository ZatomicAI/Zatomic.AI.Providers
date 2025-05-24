using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatExecutableCodePart : GoogleGeminiChatBasePart
	{
		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("language")]
		public string Language { get; set; }
	}
}
