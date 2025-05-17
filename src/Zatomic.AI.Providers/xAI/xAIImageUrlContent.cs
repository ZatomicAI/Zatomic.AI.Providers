using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIImageUrlContent : xAIBaseContent
	{
		[JsonProperty("image_url")]
		public xAIImageUrl ImageUrl { get; set; }
	}
}
