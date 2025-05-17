using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralTextContent : BaseMistralContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
