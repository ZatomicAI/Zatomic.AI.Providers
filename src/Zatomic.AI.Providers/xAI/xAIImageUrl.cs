using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIImageUrl
	{
		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
