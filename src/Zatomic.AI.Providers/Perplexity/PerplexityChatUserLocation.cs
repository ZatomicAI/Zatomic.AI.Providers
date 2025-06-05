using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatUserLocation
	{
		[JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
		public string Country { get; set; }

		[JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
		public float? Latitude { get; set; }

		[JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
		public float? Longitude { get; set; }
	}
}
