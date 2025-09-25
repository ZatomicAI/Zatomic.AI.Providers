using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Nvidia
{
	public class NvidiaChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
