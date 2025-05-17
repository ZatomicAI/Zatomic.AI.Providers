using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }
	}
}
