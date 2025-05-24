using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
