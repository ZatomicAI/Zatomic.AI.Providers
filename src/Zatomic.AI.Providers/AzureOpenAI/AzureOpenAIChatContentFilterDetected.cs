using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatContentFilterDetected
	{
		[JsonProperty("filtered")]
		public bool Filtered { get; set; }

		[JsonProperty("detected")]
		public bool Detected { get; set; }
	}
}
