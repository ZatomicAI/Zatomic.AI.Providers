using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatResponseFormat
	{
		[JsonProperty("schema", NullValueHandling = NullValueHandling.Ignore)]
		public JObject Schema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
