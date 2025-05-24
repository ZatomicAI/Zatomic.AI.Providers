using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
