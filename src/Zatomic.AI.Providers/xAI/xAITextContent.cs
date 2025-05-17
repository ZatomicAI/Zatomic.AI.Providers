using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAITextContent : xAIBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
