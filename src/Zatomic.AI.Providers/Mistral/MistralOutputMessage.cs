using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
