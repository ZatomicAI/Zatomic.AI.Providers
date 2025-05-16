using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereStreamResponse
	{
		[JsonProperty("delta")]
		public CohereStreamDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
