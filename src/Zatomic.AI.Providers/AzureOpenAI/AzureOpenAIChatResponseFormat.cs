using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public JObject JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
