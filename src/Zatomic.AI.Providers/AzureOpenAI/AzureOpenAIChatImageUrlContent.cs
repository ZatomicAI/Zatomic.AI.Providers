using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatImageUrlContent : AzureOpenAIChatBaseContent
	{
		[JsonProperty("image_url")]
		public AzureOpenAIChatImageUrl ImageUrl { get; set; }
	}
}
