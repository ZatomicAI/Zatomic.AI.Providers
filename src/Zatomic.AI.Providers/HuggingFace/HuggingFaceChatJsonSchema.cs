using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatJsonSchema
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("schema")]
		public JObject Schema { get; set; }
	}
}
