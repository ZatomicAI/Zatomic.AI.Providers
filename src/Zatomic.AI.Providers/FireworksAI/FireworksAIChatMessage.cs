using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<FireworksAIChatToolCall> ToolCalls { get; set; }

		public FireworksAIChatMessage()
		{
			ToolCalls = new List<FireworksAIChatToolCall>();
		}
	}
}
