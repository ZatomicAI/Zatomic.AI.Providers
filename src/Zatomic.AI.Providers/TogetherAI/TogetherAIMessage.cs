using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
