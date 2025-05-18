using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
