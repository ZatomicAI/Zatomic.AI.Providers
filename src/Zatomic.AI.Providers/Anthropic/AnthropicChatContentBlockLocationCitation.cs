using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatContentBlockLocationCitation : AnthropicChatBaseCitation
	{
		[JsonProperty("cited_text")]
		public string CitedText { get; set; }

		[JsonProperty("document_index")]
		public int DocumentIndex { get; set; }

		[JsonProperty("document_title")]
		public string DocumentTitle { get; set; }

		[JsonProperty("end_block_index")]
		public int EndBlockIndex { get; set; }

		[JsonProperty("start_block_index")]
		public int StartBlockIndex { get; set; }
	}
}
