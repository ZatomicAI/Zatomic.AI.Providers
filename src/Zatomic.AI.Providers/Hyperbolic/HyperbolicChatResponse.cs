using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Hyperbolic
{
	public class HyperbolicChatResponse
	{
		[JsonProperty("choices")]
		public List<HyperbolicChatChoice> Choices { get; set; }

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

		[JsonProperty("usage")]
		public HyperbolicChatUsage Usage { get; set; }

		public HyperbolicChatResponse()
		{
			Choices = new List<HyperbolicChatChoice>();
		}
	}
}
