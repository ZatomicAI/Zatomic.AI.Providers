using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatStreamMessageEnd
	{
		[JsonProperty("delta")]
		public CohereChatDelta Delta { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
