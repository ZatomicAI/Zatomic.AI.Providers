using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatContentFilterDetected
	{
		[JsonProperty("filtered")]
		public bool Filtered { get; set; }

		[JsonProperty("detected")]
		public bool Detected { get; set; }
	}
}
