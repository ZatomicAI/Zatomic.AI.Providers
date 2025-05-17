using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaTextContent : MetaBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
