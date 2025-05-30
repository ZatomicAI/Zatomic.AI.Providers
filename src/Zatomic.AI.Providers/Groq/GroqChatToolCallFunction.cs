using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatToolCallFunction
	{
		[JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
		public string Arguments { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }
	}
}
