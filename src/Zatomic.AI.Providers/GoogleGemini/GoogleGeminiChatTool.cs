using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatTool
	{
		[JsonProperty("codeExecution", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatCodeExecution CodeExecution { get; set; }

		[JsonProperty("functionDeclarations", NullValueHandling = NullValueHandling.Ignore)]
		public List<GoogleGeminiChatFunctionDeclaration> FunctionDeclarations { get; set; }

		[JsonProperty("googleSearch", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatSearch GoogleSearch { get; set; }

		[JsonProperty("googleSearchRetrieval", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatSearchRetrieval GoogleSearchRetrieval { get; set; }

		[JsonProperty("urlContext", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatUrlContext UrlContext { get; set; }
	}
}
