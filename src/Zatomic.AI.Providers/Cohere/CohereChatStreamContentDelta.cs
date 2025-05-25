using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatStreamContentDelta
	{
		[JsonProperty("delta")]
		public CohereChatDelta Delta { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
