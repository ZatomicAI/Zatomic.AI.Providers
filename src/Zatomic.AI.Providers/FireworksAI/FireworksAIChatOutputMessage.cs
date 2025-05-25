using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<FireworksAIChatToolCall> ToolCalls { get; set; }

		public FireworksAIChatOutputMessage()
		{
			ToolCalls = new List<FireworksAIChatToolCall>();
		}
	}
}
