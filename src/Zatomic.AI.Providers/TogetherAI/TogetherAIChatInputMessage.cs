using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(TogetherAIChatContentListConverter))]
		public List<TogetherAIChatBaseContent> Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<TogetherAIChatToolCall> ToolCalls { get; set; }

		public TogetherAIChatInputMessage()
		{
			Content = new List<TogetherAIChatBaseContent>();
		}
	}
}
