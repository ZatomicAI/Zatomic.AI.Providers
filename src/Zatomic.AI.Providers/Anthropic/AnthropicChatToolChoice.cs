using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatToolChoice
	{
		[JsonProperty("disable_parallel_tool_use")]
		public bool DisableParallelToolUse { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
