using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatInputMessage
	{
		[JsonProperty("content")]
		public List<xAIChatContent> Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<xAIChatToolCall> ToolCalls { get; set; }

		public xAIChatInputMessage()
		{
			Content = new List<xAIChatContent>();
		}
	}
}
