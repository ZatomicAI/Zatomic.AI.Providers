using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatRequest : BaseRequest
	{
		[JsonProperty("contents")]
		public List<GoogleGeminiChatContent> Contents { get; set; }

		[JsonProperty("generationConfig", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatGenerationConfig GenerationConfig { get; set; }

		[JsonProperty("systemInstruction", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatSystemInstruction SystemInstruction { get; set; }

		public GoogleGeminiChatRequest()
		{
			Contents = new List<GoogleGeminiChatContent>();
		}
	}
}
