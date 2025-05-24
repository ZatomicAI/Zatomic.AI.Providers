using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id")]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls")]
		public List<HuggingFaceChatToolCall> ToolCalls { get; set; }

		public HuggingFaceChatOutputMessage()
		{
			ToolCalls = new List<HuggingFaceChatToolCall>();
		}
	}
}
