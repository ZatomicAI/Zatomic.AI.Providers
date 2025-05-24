using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatFunctionDeclaration
	{
		[JsonProperty("behavior", NullValueHandling = NullValueHandling.Ignore)]
		public string Behavior { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
		public JObject Parameters { get; set; }

		[JsonProperty("response", NullValueHandling = NullValueHandling.Ignore)]
		public JObject Response { get; set; }
	}
}
