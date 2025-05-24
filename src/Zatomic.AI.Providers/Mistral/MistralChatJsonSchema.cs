using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatJsonSchema
	{
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("schema")]
		public JObject Schema { get; set; }

		[JsonProperty("strict", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Strict { get; set; }
	}
}
