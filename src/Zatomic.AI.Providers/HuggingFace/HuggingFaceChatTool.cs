using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatTool
	{
		[JsonProperty("function")]
		public HuggingFaceChatFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
