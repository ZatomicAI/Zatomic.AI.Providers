using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatSystemMessage : GroqChatBaseMessage
	{
		[JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
		public string Content { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
		public string Role { get; set; }
	}
}
