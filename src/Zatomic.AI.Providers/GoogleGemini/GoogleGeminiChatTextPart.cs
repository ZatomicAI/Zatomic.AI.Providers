using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatTextPart : GoogleGeminiChatBasePart
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
