using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatUrlContextMetadata
	{
		[JsonProperty("urlMetadata")]
		public List<GoogleGeminiChatUrlMetadata> UrlMetadata { get; set; }

		public GoogleGeminiChatUrlContextMetadata()
		{
			UrlMetadata = new List<GoogleGeminiChatUrlMetadata>();
		}
	}
}
