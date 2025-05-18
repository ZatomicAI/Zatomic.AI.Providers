using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatTextContent : MistralChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
