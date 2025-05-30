using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
