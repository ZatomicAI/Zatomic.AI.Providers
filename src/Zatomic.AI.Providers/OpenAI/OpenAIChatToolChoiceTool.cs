using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatToolChoiceTool
	{
		[JsonProperty("function")]
		public OpenAIChatToolChoiceFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
