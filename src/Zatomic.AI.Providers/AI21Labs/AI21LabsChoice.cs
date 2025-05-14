using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChoice
	{
		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("message")]
		public AI21LabsMessage Message { get; set; }

		[JsonProperty("delta")]
		public AI21LabsDelta Delta { get; set; }
	}
}
