using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicResponse
	{
		[JsonProperty("content")]
		public List<BaseAnthropicContent> Content { get; private set; }

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
		public AnthropicUsage Usage { get; set; }

		public AnthropicResponse()
		{
			Content = new List<BaseAnthropicContent>();
		}
	}
}
