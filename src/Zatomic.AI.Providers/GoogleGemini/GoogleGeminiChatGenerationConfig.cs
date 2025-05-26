using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatGenerationConfig
	{
		[JsonProperty("candidateCount", NullValueHandling = NullValueHandling.Ignore)]
		public int? CandidateCount { get; set; }

		[JsonProperty("frequencyPenalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("maxOutputTokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxOutputTokens { get; set; }

		[JsonProperty("presencePenalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("responseMimeType", NullValueHandling = NullValueHandling.Ignore)]
		public string ResponseMimeType { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Seed { get; set; }

		[JsonProperty("stopSequences", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> StopSequences { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("topK", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("topP", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }
	}
}
