using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatResponseFormat
	{
		[JsonProperty("json_schema", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatJsonSchema JsonSchema { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
