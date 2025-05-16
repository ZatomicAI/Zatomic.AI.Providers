using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }
	}
}
