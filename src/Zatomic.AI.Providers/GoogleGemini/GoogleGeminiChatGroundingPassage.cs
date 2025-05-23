using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatGroundingPassage : GoogleGeminiChatBaseAttributionSource
	{
		[JsonProperty("partIndex")]
		public int PartIndex { get; set; }

		[JsonProperty("passageId")]
		public string PassageId { get; set; }
	}
}
