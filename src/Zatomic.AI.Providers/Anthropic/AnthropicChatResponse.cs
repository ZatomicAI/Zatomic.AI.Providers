using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatResponse
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(AnthropicChatContentListConverter))]
		public List<AnthropicChatBaseContent> Content { get; set; }

		[JsonProperty("duration")]
		public decimal? Duration { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("stop_reason")]
		public string StopReason { get; set; }

		[JsonProperty("stop_sequence")]
		public string StopSequence { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("usage")]
		public AnthropicChatUsage Usage { get; set; }

		public AnthropicChatResponse()
		{
			Content = new List<AnthropicChatBaseContent>();
		}
	}
}
