using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSearch
	{
		[JsonProperty("timeRangeFilter", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatTimeRangeFilter TimeRangeFilter { get; set; }
	}
}
