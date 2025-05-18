using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
