using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatOutputMessage
	{
		[JsonProperty("annotations")]
		public List<AzureOpenAIChatAnnotation> Annotations { get; set; }

		[JsonProperty("audio")]
		public AzureOpenAIChatAudioOutput Audio { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("refusal")]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_calls")]
		public List<AzureOpenAIChatToolCall> ToolCalls { get; set; }

		public AzureOpenAIChatOutputMessage()
		{
			Annotations = new List<AzureOpenAIChatAnnotation>();
			ToolCalls = new List<AzureOpenAIChatToolCall>();
		}
	}
}
