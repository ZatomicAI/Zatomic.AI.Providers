using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatOutputMessage
	{
		[JsonProperty("annotations")]
		public List<MicrosoftFoundryChatAnnotation> Annotations { get; set; }

		[JsonProperty("audio")]
		public MicrosoftFoundryChatAudioOutput Audio { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("refusal")]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<MicrosoftFoundryChatToolCall> ToolCalls { get; set; }

		public MicrosoftFoundryChatOutputMessage()
		{
			Annotations = new List<MicrosoftFoundryChatAnnotation>();
			ToolCalls = new List<MicrosoftFoundryChatToolCall>();
		}
	}
}
