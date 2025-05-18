using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatPrediction
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
