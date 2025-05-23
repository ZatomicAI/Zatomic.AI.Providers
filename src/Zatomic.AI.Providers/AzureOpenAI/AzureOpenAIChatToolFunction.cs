using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatToolFunction
	{
		[JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
		public string Description { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
		public JObject Parameters { get; set; }

		[JsonProperty("strict", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Strict { get; set; }
	}
}
