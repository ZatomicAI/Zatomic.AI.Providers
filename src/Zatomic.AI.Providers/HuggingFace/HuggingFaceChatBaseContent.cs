using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public abstract class HuggingFaceChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
