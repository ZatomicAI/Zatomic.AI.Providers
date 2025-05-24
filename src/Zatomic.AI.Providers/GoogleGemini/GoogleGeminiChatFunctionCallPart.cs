using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatFunctionCallPart : GoogleGeminiChatBasePart
	{
		[JsonProperty("args")]
		public JObject Args { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
