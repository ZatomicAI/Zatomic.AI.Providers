using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatTool
	{
		[JsonProperty("function")]
		public MoonshotAIChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
