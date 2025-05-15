using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicImageContentSource
	{
		[JsonProperty("data")]
		public string Data { get; set; }

		[JsonProperty("media_type")]
		public string MediaType { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
