using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatFunction
	{
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("parameters")]
		public JObject Parameters { get; set; }
	}
}
