using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatBasePart
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
