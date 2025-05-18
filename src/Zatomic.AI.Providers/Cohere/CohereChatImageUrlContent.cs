using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatImageUrlContent : CohereChatBaseContent
	{
		[JsonProperty("image_url")]
		public CohereChatImageUrl ImageUrl { get; set; }
	}
}
