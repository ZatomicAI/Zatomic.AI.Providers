using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatContent
	{
		[JsonProperty("parts")]
		[JsonConverter(typeof(GoogleGeminiChatPartsListConverter))]
		public List<GoogleGeminiChatBasePart> Parts { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public GoogleGeminiChatContent()
		{
			Parts = new List<GoogleGeminiChatBasePart>();
		}
	}
}
