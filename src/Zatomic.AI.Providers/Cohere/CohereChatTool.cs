using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatTool
	{
		[JsonProperty("function", NullValueHandling = NullValueHandling.Ignore)]
		public CohereChatFunction Function { get; set; }

		[JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
		public string Type { get; set; }
	}
}
