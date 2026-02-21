using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatResponseFormat
	{
		[JsonProperty("json_schema")]
		public DatabricksChatJsonSchema JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
