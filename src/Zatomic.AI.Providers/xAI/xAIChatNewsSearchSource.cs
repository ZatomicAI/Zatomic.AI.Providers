using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatNewsSearchSource : xAIChatBaseSearchSource
	{
		[JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
		public string Country { get; set; }

		[JsonProperty("safe_search", NullValueHandling = NullValueHandling.Ignore)]
		public bool? SafeSearch { get; set; }
	}
}
