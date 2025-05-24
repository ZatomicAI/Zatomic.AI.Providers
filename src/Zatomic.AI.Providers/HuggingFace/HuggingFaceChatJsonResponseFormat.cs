using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatJsonResponseFormat : HuggingFaceChatBaseResponseFormat
	{
		[JsonProperty("value")]
		public JObject Value { get; set; }
	}
}
