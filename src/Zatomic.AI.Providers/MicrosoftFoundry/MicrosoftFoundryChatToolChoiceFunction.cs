using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatToolChoiceFunction
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
