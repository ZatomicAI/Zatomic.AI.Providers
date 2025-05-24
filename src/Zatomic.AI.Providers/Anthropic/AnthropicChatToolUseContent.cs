using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatToolUseContent : AnthropicChatBaseContent
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("input")]
		public JObject Input { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
