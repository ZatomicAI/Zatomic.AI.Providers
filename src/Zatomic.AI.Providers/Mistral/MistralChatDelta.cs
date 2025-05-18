using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
