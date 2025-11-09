using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
