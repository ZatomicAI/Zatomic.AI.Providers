using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatTextContent : xAIChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
