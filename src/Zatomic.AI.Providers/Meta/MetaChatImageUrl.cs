using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
