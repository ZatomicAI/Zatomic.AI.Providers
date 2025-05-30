using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatTool
	{
		[JsonProperty("function", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatToolFunction Function { get; set; }

		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }
	}
}
