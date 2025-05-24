using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatToolConfig
	{
		[JsonProperty("functionCallingConfig", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatFunctionCallingConfig FunctionCallingConfig { get; set; }
	}
}
