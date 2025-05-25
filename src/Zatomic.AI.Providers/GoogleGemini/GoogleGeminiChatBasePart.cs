using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public abstract class GoogleGeminiChatBasePart
	{
		[JsonProperty("thought", NullValueHandling = NullValueHandling.Ignore)]
		public bool Thought { get; set; }

		[JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(GoogleGeminiChatMetadataConverter))]
		public GoogleGeminiChatBaseMetadata Metadata { get; set; }
	}
}
