using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
