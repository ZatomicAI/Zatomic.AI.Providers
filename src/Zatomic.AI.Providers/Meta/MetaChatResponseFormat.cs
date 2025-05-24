using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public MetaChatJsonSchema JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
