using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatUsage
	{
		[JsonProperty("completion_tokens")]
		public int CompletionTokens { get; set; }

		[JsonProperty("prompt_time")]
		public decimal PromptTime { get; set; }

		[JsonProperty("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonProperty("queue_time")]
		public decimal QueueTime { get; set; }

		[JsonProperty("total_time")]
		public decimal TotalTime { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
