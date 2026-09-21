using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatImageUrlContent : MicrosoftFoundryChatBaseContent
	{
		[JsonProperty("image_url")]
		public MicrosoftFoundryChatImageUrl ImageUrl { get; set; }
	}
}
