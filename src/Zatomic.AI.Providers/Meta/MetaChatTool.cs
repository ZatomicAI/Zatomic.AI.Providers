using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatTool
	{
		[JsonProperty("function")]
		public MetaChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
