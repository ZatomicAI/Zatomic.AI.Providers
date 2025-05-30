using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatJsonSchema
	{
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("schema", NullValueHandling = NullValueHandling.Ignore)]
		public JObject Schema { get; set; }

		[JsonProperty("strict", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Strict { get; set; }
	}
}
