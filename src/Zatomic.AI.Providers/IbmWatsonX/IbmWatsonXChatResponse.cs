using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatResponse
	{
		[JsonProperty("choices")]
		public List<IbmWatsonXChatChoice> Choices { get; set; }

		[JsonProperty("created")]
		public int Created { get; set; }

		[JsonProperty("created_utc")]
		public DateTime CreatedUtc { get { return DateTimeOffset.FromUnixTimeSeconds(Created).UtcDateTime; } }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("model_id")]
		public string ModelId { get; set; }

		[JsonProperty("model_version")]
		public string ModelVersion { get; set; }

		[JsonProperty("system")]
		public IbmWatsonXChatSystem System { get; set; }

		[JsonProperty("usage")]
		public IbmWatsonXChatUsage Usage { get; set; }

		public IbmWatsonXChatResponse()
		{
			Choices = new List<IbmWatsonXChatChoice>();
		}
	}
}
