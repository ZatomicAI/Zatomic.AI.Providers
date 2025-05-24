using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatWebSearchToolResultContent : AnthropicChatBaseContent
	{
		[JsonProperty("content")]
		public AnthropicChatWebSearchToolContent Content { get; set; }

		[JsonProperty("tool_use_id")]
		public string ToolUseId { get; set; }
	}
}
