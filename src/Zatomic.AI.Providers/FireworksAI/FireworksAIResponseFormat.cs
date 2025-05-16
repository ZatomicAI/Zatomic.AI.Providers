using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
