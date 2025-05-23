using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatCandidate
    {
		[JsonProperty("citationMetadata")]
		public GoogleGeminiChatCitationMetadata CitationMetadata { get; set; }

		[JsonProperty("content")]
        public GoogleGeminiChatContent Content { get; set; }

		[JsonProperty("finishReason")]
		public string FinishReason { get; set; }

		[JsonProperty("groundingAttributions")]
		public List<GoogleGeminiChatGroundingAttribution> GroundingAttributions { get; set; }

		[JsonProperty("groundingMetadata")]
		public GoogleGeminiChatGroundingMetadata GroundingMetadata { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("safetyRatings")]
		public List<GoogleGeminiChatSafetyRating> SafetyRatings { get; set; }

		[JsonProperty("tokenCount")]
		public int TokenCount { get; set; }
		
		[JsonProperty("urlContextMetadata")]
		public GoogleGeminiChatUrlContextMetadata UrlContextMetadata { get; set; }

		[JsonProperty("urlRetrievalMetadata")]
		public GoogleGeminiChatUrlRetrievalMetadata UrlRetrievalMetadata { get; set; }

		public GoogleGeminiChatCandidate()
		{
			GroundingAttributions = new List<GoogleGeminiChatGroundingAttribution>();
			SafetyRatings = new List<GoogleGeminiChatSafetyRating>();
		}
	}
}
