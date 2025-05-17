using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAITextContent : BasexAIContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
