using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(MistralChatContentListConverter))]
		public List<MistralChatBaseContent> Content { get; set; }

		[JsonProperty("prefix", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Prefix { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public List<MistralChatToolCall> ToolCalls { get; set; }

		public MistralChatInputMessage()
		{
			Content = new List<MistralChatBaseContent>();
		}
	}
}
