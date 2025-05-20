using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatResponse
	{
		[JsonProperty("candidates")]
		public List<GoogleGeminiChatCandidate> Candidates { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("modelVersion")]
		public string ModelVersion { get; set; }

		[JsonProperty("usageMetadata")]
		public GoogleGeminiChatUsageMetadata UsageMetadata { get; set; }

		public GoogleGeminiChatResponse()
		{
			Candidates = new List<GoogleGeminiChatCandidate>();
		}
	}
}
