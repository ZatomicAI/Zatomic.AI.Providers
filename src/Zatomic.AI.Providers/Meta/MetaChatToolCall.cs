using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatToolCall
	{
		[JsonProperty("function")]
		public MetaChatToolCallFunction Function { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
