using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSafetyRating
	{
		[JsonProperty("blocked")]
		public bool Blocked { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("probability")]
		public string Probability { get; set; }
	}
}
