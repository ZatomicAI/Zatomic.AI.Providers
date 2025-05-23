using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
