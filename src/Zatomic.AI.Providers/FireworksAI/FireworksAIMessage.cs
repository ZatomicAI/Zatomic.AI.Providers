using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
