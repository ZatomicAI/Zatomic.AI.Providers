using System.Collections.Generic;
using Newtonsoft.Json;

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

		public CohereLogProb()
		{
			LogProbs = new List<float>();
			TokenIds = new List<int>();
		}
	}
}
