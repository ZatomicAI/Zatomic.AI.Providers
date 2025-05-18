using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatTextContent : CohereChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
