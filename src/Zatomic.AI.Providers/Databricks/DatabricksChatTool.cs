using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatTool
	{
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
		public DatabricksChatToolCustomFormat Format { get; set; }

		[JsonProperty("function", NullValueHandling = NullValueHandling.Ignore)]
		public DatabricksChatToolFunction Function { get; set; }

		[JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
