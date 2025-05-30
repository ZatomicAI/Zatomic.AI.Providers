using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatSearchSettings
	{
		[JsonProperty("exclude_domains", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> ExcludeDomains { get; set; }

		[JsonProperty("include_domains", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> IncludeDomains { get; set; }

		[JsonProperty("include_images", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IncludeImages { get; set; }
	}
}
