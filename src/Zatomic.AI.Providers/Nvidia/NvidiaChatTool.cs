using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Nvidia
{
	public class NvidiaChatTool
	{
		[JsonProperty("function")]
		public NvidiaChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
