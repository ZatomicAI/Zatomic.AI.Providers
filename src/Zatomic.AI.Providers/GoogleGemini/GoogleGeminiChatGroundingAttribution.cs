using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
	public class GoogleGeminiChatGroundingAttribution
	{
		[JsonProperty("content")]
		public GoogleGeminiChatContent Content { get; set; }

		[JsonProperty("sourceId")]
		[JsonConverter(typeof(GoogleGeminiChatAttributionSourceConverter))]
		public GoogleGeminiChatBaseAttributionSource SourceId { get; set; }
	}
}
