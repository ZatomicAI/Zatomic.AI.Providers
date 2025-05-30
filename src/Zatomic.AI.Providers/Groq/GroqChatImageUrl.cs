using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatImageUrl
	{
		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }

		[JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
		public string Url { get; set; }
	}
}
