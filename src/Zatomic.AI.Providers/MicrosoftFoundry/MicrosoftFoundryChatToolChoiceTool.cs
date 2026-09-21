using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatToolChoiceTool
	{
		[JsonProperty("function")]
		public MicrosoftFoundryChatToolChoiceFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
