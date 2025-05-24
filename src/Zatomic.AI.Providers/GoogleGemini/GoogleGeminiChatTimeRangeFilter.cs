using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatTimeRangeFilter
	{
		[JsonProperty("endTime")]
		public string EndTime { get; set; }

		[JsonProperty("startTime")]
		public string StartTime { get; set; }
	}
}
