using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<TogetherAIChatToolCall> ToolCalls { get; set; }

		public TogetherAIChatOutputMessage()
		{
			ToolCalls = new List<TogetherAIChatToolCall>();
		}
	}
}
