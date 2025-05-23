using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatCharacterLocationCitation : AnthropicChatBaseCitation
	{
		[JsonProperty("cited_text")]
		public string CitedText { get; set; }

		[JsonProperty("document_index")]
		public int DocumentIndex { get; set; }

		[JsonProperty("document_title")]
		public string DocumentTitle { get; set; }

		[JsonProperty("end_char_index")]
		public int EndCharIndex { get; set; }

		[JsonProperty("start_char_index")]
		public int StartCharIndex { get; set; }
	}
}
