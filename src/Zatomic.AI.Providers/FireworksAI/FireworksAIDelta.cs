using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
