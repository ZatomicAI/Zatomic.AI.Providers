using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(OpenAIChatContentListConverter))]
		public List<OpenAIChatBaseContent> Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<OpenAIChatToolCall> ToolCalls { get; set; }

		public OpenAIChatInputMessage()
		{
			Content = new List<OpenAIChatBaseContent>();
		}
	}
}
