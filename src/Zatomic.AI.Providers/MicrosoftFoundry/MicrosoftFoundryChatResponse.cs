using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatResponse
	{
		[JsonProperty("choices")]
		public List<MicrosoftFoundryChatChoice> Choices { get; set; }

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
		public List<MicrosoftFoundryChatPromptFilterResult> PromptFilterResults { get; set; }

		[JsonProperty("system_fingerprint")]
		public string SystemFingerprint { get; set; }

		[JsonProperty("usage")]
		public MicrosoftFoundryChatUsage Usage { get; set; }

		public MicrosoftFoundryChatResponse()
		{
			Choices = new List<MicrosoftFoundryChatChoice>();
			PromptFilterResults = new List<MicrosoftFoundryChatPromptFilterResult>();
		}
	}
}
