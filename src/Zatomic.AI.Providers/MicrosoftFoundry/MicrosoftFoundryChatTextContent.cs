using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatTextContent : MicrosoftFoundryChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
