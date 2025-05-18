using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatImageUrl
	{
		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
