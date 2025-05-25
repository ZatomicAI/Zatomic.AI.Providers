using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatStreamEventType
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
