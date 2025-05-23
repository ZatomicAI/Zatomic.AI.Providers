using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatToolInputSchema
	{
		[JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
		public JObject Properties { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
