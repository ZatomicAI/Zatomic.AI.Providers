using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
