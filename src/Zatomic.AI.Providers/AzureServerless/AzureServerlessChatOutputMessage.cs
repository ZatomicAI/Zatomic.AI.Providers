using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatOutputMessage
	{
		[JsonProperty("audio")]
		public AzureServerlessChatAudioOutput Audio { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("reasoning_content")]
		public string ReasoningContent { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<AzureServerlessChatToolCall> ToolCalls { get; set; }

		public AzureServerlessChatOutputMessage()
		{
			ToolCalls = new List<AzureServerlessChatToolCall>();
		}
	}
}
