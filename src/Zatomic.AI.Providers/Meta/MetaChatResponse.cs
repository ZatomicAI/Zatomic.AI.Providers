using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatResponse
	{
		[JsonProperty("completion_message")]
		public MetaChatCompletionMessage CompletionMessage { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("metrics")]
		public List<MetaChatMetric> Metrics { get; set; }

		[JsonProperty("usage")]
		public MetaChatUsage Usage
		{
			get
			{
				MetaChatUsage usage = null;

				if (Metrics.Count > 0)
				{
					usage = new MetaChatUsage();

					foreach (var m in Metrics)
					{
						if (m.Metric == "num_prompt_tokens") usage.PromptTokens = m.Value;
						else if (m.Metric == "num_completion_tokens") usage.CompletionTokens = m.Value;
						else if (m.Metric == "num_total_tokens") usage.TotalTokens = m.Value;
					}
				}

				return usage;
			}
		}

		public MetaChatResponse()
		{
			Metrics = new List<MetaChatMetric>();
		}
	}
}
