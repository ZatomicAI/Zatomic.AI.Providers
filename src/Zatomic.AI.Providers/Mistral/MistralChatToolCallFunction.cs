using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
