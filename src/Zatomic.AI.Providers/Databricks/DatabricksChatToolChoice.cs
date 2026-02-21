using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatToolChoice
	{
		[JsonProperty("function", NullValueHandling = NullValueHandling.Ignore)]
		public DatabricksChatToolFunction Function { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
