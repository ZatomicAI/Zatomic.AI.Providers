using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatCompletionMessage
	{
		[JsonProperty("content")]
		public MetaChatTextContent Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("stop_reason")]
		public string StopReason { get; set; }

		[JsonProperty("tool_calls")]
		public List<MetaChatToolCall> ToolCalls { get; set; }

		public MetaChatCompletionMessage()
		{
			ToolCalls = new List<MetaChatToolCall>();
		}
	}
}
