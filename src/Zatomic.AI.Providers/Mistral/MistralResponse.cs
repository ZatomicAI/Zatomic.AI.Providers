using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralResponse
	{
		[JsonProperty("choices")]
		public List<MistralChoice> Choices { get; set; }

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
		public MistralUsage Usage { get; set; }

		public MistralResponse()
		{
			Choices = new List<MistralChoice>();
		}
	}
}
