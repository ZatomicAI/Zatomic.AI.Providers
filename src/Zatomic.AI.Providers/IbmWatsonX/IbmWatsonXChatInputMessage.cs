using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(IbmWatsonXChatContentListConverter))]
		public List<IbmWatsonXChatBaseContent> Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("refusal", NullValueHandling = NullValueHandling.Ignore)]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<IbmWatsonXChatToolCall> ToolCalls { get; set; }

		public IbmWatsonXChatInputMessage()
		{
			Content = new List<IbmWatsonXChatBaseContent>();
		}
	}
}
