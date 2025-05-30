using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatJsonSchema JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
