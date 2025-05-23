using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatTextContent : AnthropicChatBaseContent
	{
		[JsonProperty("citations")]
		[JsonConverter(typeof(AnthropicChatCitationsListConverter))]
		public List<AnthropicChatBaseCitation> Citations { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		public AnthropicChatTextContent()
		{
			Citations = new List<AnthropicChatBaseCitation>();
		}
	}
}
