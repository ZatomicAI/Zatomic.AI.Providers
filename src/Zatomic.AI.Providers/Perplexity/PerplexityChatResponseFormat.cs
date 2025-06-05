using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public JObject JsonSchema { get; set; }

		[JsonProperty("regex", NullValueHandling = NullValueHandling.Ignore)]
		public string Regex { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
