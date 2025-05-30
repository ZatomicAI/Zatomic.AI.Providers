using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatResponse
	{
		[JsonProperty("choices")]
		public List<GroqChatChoice> Choices { get; set; }

		[JsonProperty("created")]
		public int Created { get; set; }

		[JsonProperty("created_utc")]
		public DateTime CreatedUtc { get { return DateTimeOffset.FromUnixTimeSeconds(Created).UtcDateTime; } }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("object")]
		public string Object { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("system_fingerprint")]
		public string SystemFingerprint { get; set; }

		[JsonProperty("usage")]
		public GroqChatUsage Usage { get; set; }

		public GroqChatResponse()
		{
			Choices = new List<GroqChatChoice>();
		}
	}
}
