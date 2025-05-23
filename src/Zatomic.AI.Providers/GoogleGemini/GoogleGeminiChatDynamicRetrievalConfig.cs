using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatDynamicRetrievalConfig
	{
		[JsonProperty("dynamicThreshold")]
		public float DynamicThreshold { get; set; }

		[JsonProperty("mode")]
		public string Mode { get; set; }
	}
}
