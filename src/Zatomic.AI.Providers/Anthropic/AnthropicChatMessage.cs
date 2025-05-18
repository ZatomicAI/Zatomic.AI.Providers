using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(AnthropicChatContentListConverter))]
		public List<AnthropicChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public AnthropicChatMessage()
		{
			Content = new List<AnthropicChatBaseContent>();
		}
	}
}
