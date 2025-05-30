using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatToolMessage : GroqChatBaseMessage
	{
		[JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
		public string Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }
	}
}
