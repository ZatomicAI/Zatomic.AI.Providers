using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Hyperbolic
{
	public class HyperbolicChatMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
