using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicRedactedThinkingContent : BaseAnthropicContent
	{
		[JsonProperty("data")]
		public string Data { get; set; }
	}
}
