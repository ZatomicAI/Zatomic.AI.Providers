using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatOutputMessage
	{
		[JsonProperty("citations")]
		public List<CohereChatCitation> Citations { get; set; }

		[JsonProperty("content")]
		public List<CohereChatTextContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<CohereChatToolCall> ToolCalls { get; set; }

		[JsonProperty("tool_plan")]
		public string ToolPlan { get; set; }

		public CohereChatOutputMessage()
		{
			Citations = new List<CohereChatCitation>();
			Content = new List<CohereChatTextContent>();
			ToolCalls = new List<CohereChatToolCall>();
		}
	}
}
