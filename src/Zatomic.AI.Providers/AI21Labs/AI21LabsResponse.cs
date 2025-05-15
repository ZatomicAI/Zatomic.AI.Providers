using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsResponse
	{
		[JsonProperty("choices")]
		public List<AI21LabsChoice> Choices { get; private set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("usage")]
		public AI21LabsUsage Usage { get; set; }

		public AI21LabsResponse()
		{
			Choices = new List<AI21LabsChoice>();
		}
	}
}
