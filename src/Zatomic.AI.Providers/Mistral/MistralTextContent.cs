using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralTextContent : MistralBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
