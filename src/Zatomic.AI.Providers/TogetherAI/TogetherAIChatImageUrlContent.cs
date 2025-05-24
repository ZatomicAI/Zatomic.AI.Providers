using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatImageUrlContent : TogetherAIChatBaseContent
	{
		[JsonProperty("image_url")]
		public TogetherAIChatImageUrl ImageUrl { get; set; }
	}
}
