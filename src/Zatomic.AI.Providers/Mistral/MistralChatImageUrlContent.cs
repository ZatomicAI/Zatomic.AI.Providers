using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatImageUrlContent : MistralChatBaseContent
	{
		[JsonProperty("image_url")]
		public MistralChatImageUrl ImageUrl { get; set; }
	}
}
