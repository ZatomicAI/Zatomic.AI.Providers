using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
