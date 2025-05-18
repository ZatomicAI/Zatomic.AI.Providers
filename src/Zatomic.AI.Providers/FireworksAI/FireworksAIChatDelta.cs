using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
