using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatInputMessage
	{
		[JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(HuggingFaceChatContentListConverter))]
		public List<HuggingFaceChatBaseContent> Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<HuggingFaceChatToolCall> ToolCalls { get; set; }
	}
}
