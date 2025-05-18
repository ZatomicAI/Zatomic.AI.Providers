using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatStreamMessage
	{
		[JsonProperty("content")]
		public CohereChatTextContent Content { get; set; }
	}
}
