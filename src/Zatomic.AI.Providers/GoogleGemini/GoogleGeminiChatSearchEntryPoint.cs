using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatSearchEntryPoint
	{
		[JsonProperty("renderedContent")]
		public string RenderedContent { get; set; }

		[JsonProperty("sdkBlob")]
		public string SdkBlob { get; set; }
	}
}
