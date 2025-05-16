using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
