using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatStreamEvent
	{
		[JsonProperty("delta")]
		public CohereChatStreamDelta Delta { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
