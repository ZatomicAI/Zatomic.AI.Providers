using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public abstract class MistralBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
