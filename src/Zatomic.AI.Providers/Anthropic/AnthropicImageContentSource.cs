using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicImageContentSource
	{
		[JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
		public string Data { get; set; }

		[JsonProperty("media_type", NullValueHandling = NullValueHandling.Ignore)]
		public string MediaType { get; set; }

		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }

		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string Url { get; set; }
	}
}
