using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatJsonSchemaResponseFormat : HuggingFaceChatBaseResponseFormat
	{
		[JsonProperty("value")]
		public HuggingFaceChatJsonSchema Value { get; set; }
	}
}
