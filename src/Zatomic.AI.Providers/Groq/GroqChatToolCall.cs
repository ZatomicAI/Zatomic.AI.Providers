using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatToolCall
	{
		[JsonProperty("function", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatToolCallFunction Function { get; set; }

		[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
		public string Id { get; set; }

		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }
	}
}
