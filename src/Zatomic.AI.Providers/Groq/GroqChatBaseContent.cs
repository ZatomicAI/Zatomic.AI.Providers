using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public abstract class GroqChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
