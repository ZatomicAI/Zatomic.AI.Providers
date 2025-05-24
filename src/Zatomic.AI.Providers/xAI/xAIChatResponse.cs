using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatResponse
	{
		[JsonProperty("choices")]
		public List<xAIChatChoice> Choices { get; set; }

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

		[JsonProperty("system_fingerprint")]
		public string SystemFingerprint { get; set; }

		[JsonProperty("usage")]
		public xAIChatUsage Usage { get; set; }

		public xAIChatResponse()
		{
			Choices = new List<xAIChatChoice>();
			Citations = new List<string>();
		}
	}
}
