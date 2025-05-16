using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaTextContent : BaseMetaContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
