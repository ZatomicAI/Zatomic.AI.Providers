using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatGroundingMetadata
	{
		[JsonProperty("groundingChunks")]
		public List<GoogleGeminiChatGroundingChunk> GroundingChunks { get; set; }

		[JsonProperty("groundingSupports")]
		public List<GoogleGeminiChatGroundingSupport> GroundingSupports { get; set; }

		[JsonProperty("retrievalMetadata")]
		public GoogleGeminiChatRetrievalMetadata RetrievalMetadata { get; set; }

		[JsonProperty("searchEntryPoint")]
		public GoogleGeminiChatSearchEntryPoint SearchEntryPoint { get; set; }

		[JsonProperty("webSearchQueries")]
		public List<string> WebSearchQueries { get; set; }

		public GoogleGeminiChatGroundingMetadata()
		{
			GroundingChunks = new List<GoogleGeminiChatGroundingChunk>();
			GroundingSupports = new List<GoogleGeminiChatGroundingSupport>();
			WebSearchQueries = new List<string>();
		}
	}
}
