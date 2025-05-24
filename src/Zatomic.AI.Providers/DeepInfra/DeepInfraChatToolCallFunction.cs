using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
