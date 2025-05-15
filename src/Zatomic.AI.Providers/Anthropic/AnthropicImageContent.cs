using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicImageContent : BaseAnthropicContent
	{
		[JsonProperty("source")]
		public AnthropicImageContentSource Source { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; } = "image";
	}
}
