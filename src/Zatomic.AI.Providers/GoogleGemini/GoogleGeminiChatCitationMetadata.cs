using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatCitationMetadata
	{
		[JsonProperty("citationSources")]
		public List<GoogleGeminiChatCitationSource> CitationSources { get; set; }

		public GoogleGeminiChatCitationMetadata()
		{
			CitationSources = new List<GoogleGeminiChatCitationSource>();
		}
	}
}
