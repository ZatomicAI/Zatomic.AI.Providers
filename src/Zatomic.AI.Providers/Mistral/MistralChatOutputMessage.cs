using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<MistralChatToolCall> ToolCalls { get; set; }

		public MistralChatOutputMessage()
		{
			ToolCalls = new List<MistralChatToolCall>();
		}
	}
}
