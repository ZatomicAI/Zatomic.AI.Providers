using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<DeepInfraChatToolCall> ToolCalls { get; set; }

		public DeepInfraChatOutputMessage()
		{
			ToolCalls = new List<DeepInfraChatToolCall>();
		}
	}
}
