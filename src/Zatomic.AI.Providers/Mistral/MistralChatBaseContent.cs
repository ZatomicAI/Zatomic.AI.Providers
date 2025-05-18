using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public abstract class MistralChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
