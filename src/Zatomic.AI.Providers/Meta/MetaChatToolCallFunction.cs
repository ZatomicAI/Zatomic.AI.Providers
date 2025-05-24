using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
