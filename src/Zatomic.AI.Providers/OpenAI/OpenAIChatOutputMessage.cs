using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatOutputMessage
	{
		[JsonProperty("annotations")]
		public List<OpenAIChatAnnotation> Annotations { get; set; }

		[JsonProperty("audio")]
		public OpenAIChatAudioOutput Audio { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("refusal")]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<OpenAIChatToolCall> ToolCalls { get; set; }

		public OpenAIChatOutputMessage()
		{
			Annotations = new List<OpenAIChatAnnotation>();
			ToolCalls = new List<OpenAIChatToolCall>();
		}
	}
}
