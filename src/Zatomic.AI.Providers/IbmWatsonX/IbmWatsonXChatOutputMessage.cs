using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("refusal")]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<IbmWatsonXChatToolCall> ToolCalls { get; set; }

		public IbmWatsonXChatOutputMessage()
		{
			ToolCalls = new List<IbmWatsonXChatToolCall>();
		}
	}
}
