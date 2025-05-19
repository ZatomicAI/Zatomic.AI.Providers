using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatTextContent : HuggingFaceChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
