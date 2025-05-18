using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatMetric
	{
		[JsonProperty("metric")]
		public string Metric { get; set; }

		[JsonProperty("unit")]
		public string Unit { get; set; }

		[JsonProperty("value")]
		public int Value { get; set; }
	}
}
