using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatDeltaMessage
	{
		[JsonProperty("content")]
		public CohereChatTextContent Content { get; set; }
	}
}
