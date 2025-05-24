using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatTool
	{
		[JsonProperty("function")]
		public DeepInfraChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
