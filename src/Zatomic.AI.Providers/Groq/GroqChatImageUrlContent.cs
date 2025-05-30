using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatImageUrlContent : GroqChatBaseContent
	{
		[JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatImageUrl ImageUrl { get; set; }
	}
}
