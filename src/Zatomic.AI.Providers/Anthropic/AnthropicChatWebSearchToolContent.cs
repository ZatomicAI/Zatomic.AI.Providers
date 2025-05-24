using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatWebSearchToolContent
	{
		[JsonProperty("error_code")]
		public string ErrorCode { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
