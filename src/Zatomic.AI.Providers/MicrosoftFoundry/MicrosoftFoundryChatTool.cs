using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatTool
	{
		[JsonProperty("function")]
		public MicrosoftFoundryChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
