using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatTool
	{
		[JsonProperty("function")]
		public FireworksAIChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
