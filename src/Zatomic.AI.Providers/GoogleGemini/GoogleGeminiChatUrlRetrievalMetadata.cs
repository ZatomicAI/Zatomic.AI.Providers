using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatUrlRetrievalMetadata
	{
		[JsonProperty("urlRetrievalContexts")]
		public List<GoogleGeminiChatUrlRetrievalContext> UrlRetrievalContexts { get; set; }

		public GoogleGeminiChatUrlRetrievalMetadata()
		{
			UrlRetrievalContexts = new List<GoogleGeminiChatUrlRetrievalContext>();
		}
	}
}
