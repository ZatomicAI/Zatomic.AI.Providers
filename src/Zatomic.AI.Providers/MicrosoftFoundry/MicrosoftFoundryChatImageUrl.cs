using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatImageUrl
	{
		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
