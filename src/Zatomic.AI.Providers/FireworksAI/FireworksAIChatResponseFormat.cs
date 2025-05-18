using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
