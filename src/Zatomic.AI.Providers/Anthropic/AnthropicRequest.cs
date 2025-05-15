using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicRequest
	{
		[JsonProperty("max_tokens")]
		public int MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AnthropicMessage> Messages { get; set; }

		[JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicMetadata Metadata { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("stop_sequences", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> StopSequences { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
		public string System { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("thinking", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicThinking Thinking { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public AnthropicRequest()
		{
			Messages = new List<AnthropicMessage>();
		}
	}
}
