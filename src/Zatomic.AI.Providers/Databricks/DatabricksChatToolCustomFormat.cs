using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatToolCustomFormat
	{
		[JsonProperty("definition", NullValueHandling = NullValueHandling.Ignore)]
		public string Definition { get; set; }

		[JsonProperty("syntax", NullValueHandling = NullValueHandling.Ignore)]
		public string Syntax { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
