using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatUserLocation
	{
		[JsonProperty("approximate")]
		public OpenAIChatUserLocationApproximate approximate { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
