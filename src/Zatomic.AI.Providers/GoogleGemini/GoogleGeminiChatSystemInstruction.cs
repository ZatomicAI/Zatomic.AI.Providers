using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSystemInstruction
	{
        [JsonProperty("parts")]
		[JsonConverter(typeof(GoogleGeminiChatPartsListConverter))]
		public List<GoogleGeminiChatBasePart> Parts { get; set; }

        public GoogleGeminiChatSystemInstruction()
        {
			Parts = new List<GoogleGeminiChatBasePart>();
		}
	}
}
