using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicStreamMessageStart
	{
		[JsonProperty("message")]
		public AnthropicResponse Message { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
