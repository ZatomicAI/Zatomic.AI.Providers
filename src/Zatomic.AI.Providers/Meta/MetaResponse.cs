using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaResponse
	{
		[JsonProperty("completion_message")]
		public MetaCompletionMessage CompletionMessage { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("metrics")]
		public List<MetaMetric> Metrics { get; set; }

		[JsonProperty("usage")]
		public MetaUsage Usage
		{
			get
			{
				MetaUsage usage = null;

				if (Metrics.Count > 0)
				{
					usage = new MetaUsage();

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

		public MetaResponse()
		{
			Metrics = new List<MetaMetric>();
		}
	}
}
