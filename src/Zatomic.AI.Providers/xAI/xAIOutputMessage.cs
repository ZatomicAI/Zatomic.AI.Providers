using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("reasoning_content")]
		public string ReasoningContent { get; set; }

		[JsonProperty("refusal")]
		public string Refusal { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
