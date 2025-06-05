using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatResponse
	{
		[JsonProperty("choices")]
		public List<PerplexityChatChoice> Choices { get; set; }

		[JsonProperty("citations")]
		public List<string> Citations { get; set; }

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

		[JsonProperty("search_results")]
		public List<PerplexityChatSearchResults> SearchResults { get; set; }

		[JsonProperty("usage")]
		public PerplexityChatUsage Usage { get; set; }

		public PerplexityChatResponse()
		{
			Choices = new List<PerplexityChatChoice>();
			Citations = new List<string>();
			SearchResults = new List<PerplexityChatSearchResults>();
		}
	}
}
