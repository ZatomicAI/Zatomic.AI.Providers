using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatTextContent : AnthropicChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
