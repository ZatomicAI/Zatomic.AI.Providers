using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatTextContent : OpenAIChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
