using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatToolCall
	{
		[JsonProperty("function")]
		public FireworksAIChatToolCallFunction Function { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
