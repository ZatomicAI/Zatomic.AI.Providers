using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatRegexResponseFormat : HuggingFaceChatBaseResponseFormat
	{
		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
