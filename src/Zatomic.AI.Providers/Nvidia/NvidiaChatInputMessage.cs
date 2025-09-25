using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Nvidia
{
	public class NvidiaChatInputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<NvidiaChatToolCall> ToolCalls { get; set; }
	}
}
