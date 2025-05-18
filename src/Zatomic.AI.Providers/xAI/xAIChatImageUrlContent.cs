using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatImageUrlContent : xAIChatBaseContent
	{
		[JsonProperty("image_url")]
		public xAIChatImageUrl ImageUrl { get; set; }
	}
}
