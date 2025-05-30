using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatTextContent : GroqChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
