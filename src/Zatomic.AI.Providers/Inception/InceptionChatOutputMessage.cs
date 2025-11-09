using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<InceptionChatToolCall> ToolCalls { get; set; }

		public InceptionChatOutputMessage()
		{
			ToolCalls = new List<InceptionChatToolCall>();
		}
	}
}
