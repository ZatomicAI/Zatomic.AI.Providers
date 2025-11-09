using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatResponse
	{
		[JsonProperty("choices")]
		public List<InceptionChatChoice> Choices { get; set; }

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
		public InceptionChatUsage Usage { get; set; }

		[JsonProperty("warning")]
		public string Warning { get; set; }

		public InceptionChatResponse()
		{
			Choices = new List<InceptionChatChoice>();
		}
	}
}
