using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
