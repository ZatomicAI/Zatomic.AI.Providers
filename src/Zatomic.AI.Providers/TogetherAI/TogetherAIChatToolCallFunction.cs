using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
