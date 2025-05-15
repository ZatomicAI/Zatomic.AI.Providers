using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicMetadata
	{
		[JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
		public string UserId { get; set; }
	}
}
