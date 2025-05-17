using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
