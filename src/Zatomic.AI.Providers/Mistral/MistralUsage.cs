using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralUsage
	{
		[JsonProperty("completion_tokens")]
		public int CompletionTokens { get; set; }

		[JsonProperty("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
