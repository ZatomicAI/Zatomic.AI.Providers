using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatTool
	{
		[JsonProperty("function")]
		public xAIChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
