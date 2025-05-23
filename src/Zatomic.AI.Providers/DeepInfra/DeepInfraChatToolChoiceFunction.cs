using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatToolChoiceFunction
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
