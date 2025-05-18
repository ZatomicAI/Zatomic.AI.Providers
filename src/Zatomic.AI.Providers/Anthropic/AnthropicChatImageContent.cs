using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatImageContent : AnthropicChatBaseContent
	{
		[JsonProperty("source")]
		public AnthropicChatImageContentSource Source { get; set; }
	}
}
