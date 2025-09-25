using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Nvidia
{
	public class NvidiaChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id")]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls")]
		public List<NvidiaChatToolCall> ToolCalls { get; set; }

		public NvidiaChatOutputMessage()
		{
			ToolCalls = new List<NvidiaChatToolCall>();
		}
	}
}
