using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatToolCall
	{
		[JsonProperty("function")]
		public TogetherAIChatToolCallFunction Function { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
