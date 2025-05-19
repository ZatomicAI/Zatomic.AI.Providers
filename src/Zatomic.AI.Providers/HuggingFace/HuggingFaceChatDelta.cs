using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
