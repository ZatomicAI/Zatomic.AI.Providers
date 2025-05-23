using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatPromptFeedback
	{
		[JsonProperty("blockReason")]
		public string BlockReason { get; set; }

		[JsonProperty("safetyRatings")]
		public List<GoogleGeminiChatSafetyRating> SafetyRatings { get; set; }

		public GoogleGeminiChatPromptFeedback()
		{
			SafetyRatings = new List<GoogleGeminiChatSafetyRating>();
		}
	}
}
