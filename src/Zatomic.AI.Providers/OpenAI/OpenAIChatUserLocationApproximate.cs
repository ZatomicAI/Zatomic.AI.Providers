using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatUserLocationApproximate
	{
		[JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
		public string City { get; set; }

		[JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
		public string Country { get; set; }

		[JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
		public string Region { get; set; }

		[JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
		public string TimeZone { get; set; }
	}
}
