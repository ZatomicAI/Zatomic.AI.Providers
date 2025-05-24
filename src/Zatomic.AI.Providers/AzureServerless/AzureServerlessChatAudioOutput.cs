using System;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatAudioOutput
	{
		[JsonProperty("data")]
		public string Data { get; set; }

		[JsonProperty("expires_at")]
		public int ExpiresAt { get; set; }

		[JsonProperty("expires_at_utc")]
		public DateTime ExpiresAtUtc { get { return DateTimeOffset.FromUnixTimeSeconds(ExpiresAt).UtcDateTime; } }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("transcript")]
		public string Transcript { get; set; }
	}
}
