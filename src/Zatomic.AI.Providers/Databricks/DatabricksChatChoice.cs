using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatChoice
	{
		[JsonProperty("delta")]
		public DatabricksChatMessage Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public DatabricksChatMessage Message { get; set; }
	}
}
