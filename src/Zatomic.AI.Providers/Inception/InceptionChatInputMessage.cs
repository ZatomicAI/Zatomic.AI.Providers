using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatInputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
