using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatUserLocation
	{
		[JsonProperty("approximate")]
		public OpenAIChatUserLocationApproximate Approximate { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
