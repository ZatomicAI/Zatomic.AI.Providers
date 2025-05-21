using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatImageUrlContent : OpenAIChatBaseContent
	{
		[JsonProperty("image_url")]
		public OpenAIChatImageUrl ImageUrl { get; set; }
	}
}
