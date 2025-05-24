using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatCustomTool : AnthropicChatBaseTool
	{
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("input_schema")]
		public AnthropicChatToolInputSchema InputSchema { get; set; }
	}
}
