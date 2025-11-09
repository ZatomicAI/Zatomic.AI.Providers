using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatToolCall
	{
		[JsonProperty("function")]
		public InceptionChatToolCallFunction Function { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("index", NullValueHandling = NullValueHandling.Ignore)]
		public int Index { get; set; }

		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }
	}
}
