using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatTextContent : MetaChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
