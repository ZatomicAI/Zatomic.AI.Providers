using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Nvidia
{
	public class NvidiaChatToolCall
	{
		[JsonProperty("function")]
		public NvidiaChatToolCallFunction Function { get; set; }

		[JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
