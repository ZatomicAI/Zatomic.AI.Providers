using Newtonsoft.Json;

namespace Zatomic.AI.Providers
{
	public class AIStreamResponse
	{
		[JsonProperty("chunk")]
		public string Chunk { get; set; }

		[JsonProperty("input_tokens")]
		public int? InputTokens { get; set; }
		
		[JsonProperty("output_tokens")]
		public int? OutputTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int? TotalTokens { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("has_error")]
		public bool HasError { get; set; }

		[JsonProperty("metadata")]
		public string Metadata { get; set; }
	}
}
