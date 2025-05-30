using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatAssistantMessage : GroqChatBaseMessage
	{
		[JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
		public string Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("reasoning", NullValueHandling = NullValueHandling.Ignore)]
		public string Reasoning { get; set; }

		[JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<GroqChatToolCall> ToolCalls { get; set; }
	}
}
