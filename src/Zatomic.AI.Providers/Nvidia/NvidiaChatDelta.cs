using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Nvidia
{
	public class NvidiaChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
