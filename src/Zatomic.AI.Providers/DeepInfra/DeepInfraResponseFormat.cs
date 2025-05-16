using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
