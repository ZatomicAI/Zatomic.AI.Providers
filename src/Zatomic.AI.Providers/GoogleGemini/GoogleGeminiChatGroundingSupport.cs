using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatGroundingSupport
	{
		[JsonProperty("confidenceScores")]
		public List<float> ConfidenceScores { get; set; }

		[JsonProperty("groundingChunkIndices")]
		public List<int> GroundingChunkIndices { get; set; }

		[JsonProperty("segment")]
		public GoogleGeminiChatSegment Segment { get; set; }

		public GoogleGeminiChatGroundingSupport()
		{
			ConfidenceScores = new List<float>();
			GroundingChunkIndices = new List<int>();
		}
	}
}
