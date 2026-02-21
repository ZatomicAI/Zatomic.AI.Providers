using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
