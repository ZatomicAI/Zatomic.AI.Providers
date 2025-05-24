using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatCitationOptions
	{
		[JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
		public string Mode { get; set; }
	}
}
