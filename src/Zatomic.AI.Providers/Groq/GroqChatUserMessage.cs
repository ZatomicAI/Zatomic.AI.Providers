using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatUserMessage : GroqChatBaseMessage
	{
		[JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(GroqChatContentListConverter))]
		public List<GroqChatBaseContent> Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
		public string Role { get; set; }

		public GroqChatUserMessage()
		{
			Content = new List<GroqChatBaseContent>();
		}
	}
}
