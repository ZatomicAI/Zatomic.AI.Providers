using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatResponse
	{
		[JsonProperty("choices")]
		public List<AI21LabsChatChoice> Choices { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("usage")]
		public AI21LabsChatUsage Usage { get; set; }

		public AI21LabsChatResponse()
		{
			Choices = new List<AI21LabsChatChoice>();
		}
	}
}
