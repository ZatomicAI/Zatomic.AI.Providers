using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public abstract class HuggingFaceChatBaseResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
