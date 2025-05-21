using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(OpenAIChatContentListConverter))]
		public List<OpenAIChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public OpenAIChatInputMessage()
		{
			Content = new List<OpenAIChatBaseContent>();
		}
	}
}
