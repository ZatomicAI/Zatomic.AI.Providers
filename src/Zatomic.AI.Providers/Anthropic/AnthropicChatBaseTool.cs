using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public abstract class AnthropicChatBaseTool
	{
		[JsonProperty("cache_control", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicChatToolCacheControl CacheControl { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
