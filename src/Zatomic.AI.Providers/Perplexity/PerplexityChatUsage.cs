using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatUsage
	{
		[JsonProperty("citation_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? CitationTokens { get; set; }

		[JsonProperty("completion_tokens")]
		public int CompletionTokens { get; set; }

		[JsonProperty("num_search_queries", NullValueHandling = NullValueHandling.Ignore)]
		public int? NumSearchQueries { get; set; }

		[JsonProperty("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonProperty("reasoning_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? ReasoningTokens { get; set; }

		[JsonProperty("search_contet_size", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchContextSize { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
