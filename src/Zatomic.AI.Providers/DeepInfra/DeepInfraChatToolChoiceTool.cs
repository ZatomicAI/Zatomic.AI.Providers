using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatToolChoiceTool
	{
		[JsonProperty("function")]
		public DeepInfraChatToolChoiceFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
