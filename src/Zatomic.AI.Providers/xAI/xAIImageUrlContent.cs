using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIImageUrlContent : BasexAIContent
	{
		[JsonProperty("image_url")]
		public xAIImageUrl ImageUrl { get; set; }
	}
}
