using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public abstract class GoogleGeminiChatBasePart
	{
		[JsonProperty("thought")]
		public bool Thought { get; set; }

		[JsonProperty("metadata")]
		[JsonConverter(typeof(GoogleGeminiChatMetadataConverter))]
		public GoogleGeminiChatBaseMetadata Metadata { get; set; }
	}
}
