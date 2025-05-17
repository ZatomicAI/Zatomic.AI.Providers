using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIResponse
	{
		[JsonProperty("choices")]
		public List<TogetherAIChoice> Choices { get; set; }

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
		public TogetherAIUsage Usage { get; set; }

		public TogetherAIResponse()
		{
			Choices = new List<TogetherAIChoice>();
		}
	}
}
