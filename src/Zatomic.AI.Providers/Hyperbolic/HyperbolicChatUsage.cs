﻿using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Hyperbolic
{
	public class HyperbolicChatUsage
	{
		[JsonProperty("completion_tokens")]
		public int CompletionTokens { get; set; }

		[JsonProperty("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonProperty("total_tokens")]
		public int TotalTokens { get; set; }
	}
}
