using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatCitationSource
	{
		[JsonProperty("endIndex")]
		public int EndIndex { get; set; }

		[JsonProperty("license")]
		public string License { get; set; }

		[JsonProperty("startIndex")]
		public int StartIndex { get; set; }

		[JsonProperty("uri")]
		public string Uri { get; set; }
	}
}
