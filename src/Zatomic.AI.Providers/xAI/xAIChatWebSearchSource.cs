using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatWebSearchSource : xAIChatBaseSearchSource
	{
		[JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
		public string Country { get; set; }

		[JsonProperty("excluded_websites", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> ExcludedWebsites { get; set; }

		[JsonProperty("safe_search", NullValueHandling = NullValueHandling.Ignore)]
		public bool? SafeSearch { get; set; }
	}
}
