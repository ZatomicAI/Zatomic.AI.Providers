using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSafetySetting
	{
		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("threshold")]
		public string Threshold { get; set; }
	}
}
