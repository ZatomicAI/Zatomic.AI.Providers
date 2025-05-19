using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
