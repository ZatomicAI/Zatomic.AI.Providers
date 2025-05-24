using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSegment
	{
		[JsonProperty("endIndex")]
		public int EndIndex { get; set; }

		[JsonProperty("partIndex")]
		public int PartIndex { get; set; }

		[JsonProperty("startIndex")]
		public int StartIndex { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
