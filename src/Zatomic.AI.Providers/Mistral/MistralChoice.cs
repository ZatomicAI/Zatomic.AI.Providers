using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChoice
	{
		[JsonProperty("delta")]
		public MistralDelta Delta { get; set; }

		[JsonProperty("finish_reason")]
		public string FinishReason { get; set; }

		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("message")]
		public MistralOutputMessage Message { get; set; }
	}
}
