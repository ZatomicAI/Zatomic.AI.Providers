using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public abstract class GoogleGeminiChatBasePart
	{
		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }
	}
}
