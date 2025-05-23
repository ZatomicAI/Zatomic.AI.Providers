using System;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatAudioOutput
	{
		[JsonProperty("data")]
		public string Data { get; set; }

		[JsonProperty("expires_at")]
		public int ExpiresAt { get; set; }

		[JsonProperty("expires_at_utc")]
		public DateTime ExpiresAtUtc { get { return DateTimeOffset.FromUnixTimeSeconds(ExpiresAt).UtcDateTime; } }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("transcript")]
		public string Transcript { get; set; }
	}
}
