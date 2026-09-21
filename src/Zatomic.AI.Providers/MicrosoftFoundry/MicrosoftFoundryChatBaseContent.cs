using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public abstract class MicrosoftFoundryChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
