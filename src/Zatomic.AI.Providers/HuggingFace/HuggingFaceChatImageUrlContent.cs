using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatImageUrlContent : HuggingFaceChatBaseContent
	{
		[JsonProperty("image_url")]
		public HuggingFaceChatImageUrl ImageUrl { get; set; }
	}
}
