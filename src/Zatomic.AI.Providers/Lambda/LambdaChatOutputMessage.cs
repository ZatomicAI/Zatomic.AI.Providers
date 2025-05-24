using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("reasoning_content")]
		public string ReasoningContent { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<LambdaChatToolCall> ToolCalls { get; set; }

		public LambdaChatOutputMessage()
		{
			ToolCalls = new List<LambdaChatToolCall>();
		}
	}
}
