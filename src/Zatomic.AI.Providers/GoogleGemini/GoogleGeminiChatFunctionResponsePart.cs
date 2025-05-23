using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatFunctionResponsePart : GoogleGeminiChatBasePart
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("response")]
		public JObject Response { get; set; }

		[JsonProperty("scheduling")]
		public string Scheduling { get; set; }

		[JsonProperty("willContinue")]
		public bool WillContinue { get; set; }
	}
}
