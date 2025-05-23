using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatPageLocationCitation : AnthropicChatBaseCitation
	{
		[JsonProperty("cited_text")]
		public string CitedText { get; set; }

		[JsonProperty("document_index")]
		public int DocumentIndex { get; set; }

		[JsonProperty("document_title")]
		public string DocumentTitle { get; set; }

		[JsonProperty("end_page_number")]
		public int EndPageNumber { get; set; }

		[JsonProperty("start_page_number")]
		public int StartPageNumber { get; set; }
	}
}
