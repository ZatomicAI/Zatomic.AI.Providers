using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatResponse
	{
		[JsonProperty("choices")]
		public List<AzureServerlessChatChoice> Choices { get; set; }

		[JsonProperty("created")]
		public int Created { get; set; }

		[JsonProperty("created_utc")]
		public DateTime CreatedUtc { get { return DateTimeOffset.FromUnixTimeSeconds(Created).UtcDateTime; } }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("prompt_filter_results")]
		public List<AzureServerlessChatPromptFilterResult> PromptFilterResults { get; set; }

		[JsonProperty("usage")]
		public AzureServerlessChatUsage Usage { get; set; }

		public AzureServerlessChatResponse()
		{
			Choices = new List<AzureServerlessChatChoice>();
		}
	}
}
