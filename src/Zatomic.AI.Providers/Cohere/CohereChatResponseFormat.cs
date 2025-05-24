using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public JObject JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
