using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatToolChoiceTool
	{
		[JsonProperty("function")]
		public xAIChatToolChoiceFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
