using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatOutputMessage
	{
		[JsonProperty("annotations")]
		public List<OpenAIChatAnnotation> Annotations { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("refusal")]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public OpenAIChatOutputMessage()
		{
			Annotations = new List<OpenAIChatAnnotation>();
		}
	}
}
