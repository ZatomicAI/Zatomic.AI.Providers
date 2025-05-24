using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public AzureServerlessChatJsonSchema JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
