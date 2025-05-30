using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
