using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatWebSearchTool : AnthropicChatBaseTool
	{
		[JsonProperty("allowed_domains", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> AllowedDomains { get; set; }

		[JsonProperty("blocked_domains", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> BlockedDomains { get; set; }

		[JsonProperty("max_uses", NullValueHandling = NullValueHandling.Ignore)]
		public int MaxUses { get; set; }

		[JsonProperty("user_location", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicChatUserLocation UserLocation { get; set; }
	}
}
