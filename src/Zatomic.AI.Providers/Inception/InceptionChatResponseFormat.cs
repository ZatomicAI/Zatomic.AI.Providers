using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
