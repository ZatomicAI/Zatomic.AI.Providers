using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatWebSearchResultLocationCitation : AnthropicChatBaseCitation
	{
		[JsonProperty("cited_text")]
		public string CitedText { get; set; }

		[JsonProperty("encrypted_index")]
		public string EncryptedIndex { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
