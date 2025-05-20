using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatUsageMetadata
	{
		[JsonProperty("candidatesTokenCount")]
		public int CandidatesTokenCount { get; set; }

		[JsonProperty("promptTokenCount")]
        public int PromptTokenCount { get; set; }

		[JsonProperty("totalTokenCount")]
		public int TotalTokenCount { get; set; }
	}
}
