using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereLogProb
	{
		[JsonProperty("logprobs")]
		public List<float> LogProbs { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("token_ids")]
		public List<int> TokenIds { get; set; }
	}
}
