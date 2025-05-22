using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatChoice
	{
		[JsonProperty("delta")]
		public AI21LabsChatDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public AI21LabsChatMessage Message { get; set; }

		[JsonProperty("tool_calls")]
		public List<AI21LabsChatToolCall> ToolCalls { get; set; }

		public AI21LabsChatChoice()
		{
			ToolCalls = new List<AI21LabsChatToolCall>();
		}
	}
}
