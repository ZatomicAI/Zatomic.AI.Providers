using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereResponse
	{
		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("logprobs")]
		public List<CohereLogProb> LogProbs { get; set; }

		[JsonProperty("message")]
		public CohereOutputMessage Message { get; set; }

		[JsonProperty("usage")]
		public CohereUsage Usage { get; set; }
	}
}
