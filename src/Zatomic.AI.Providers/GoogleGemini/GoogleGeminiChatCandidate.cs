using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatCandidate
    {
        [JsonProperty("content")]
        public GoogleGeminiChatContent Content { get; set; }

		[JsonProperty("finishReason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }
	}
}
