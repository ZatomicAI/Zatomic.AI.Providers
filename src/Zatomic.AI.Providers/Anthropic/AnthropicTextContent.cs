using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicTextContent : BaseAnthropicContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; } = "text";
	}
}
