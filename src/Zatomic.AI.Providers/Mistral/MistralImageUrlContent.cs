using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralImageUrlContent : MistralBaseContent
	{
		[JsonProperty("image_url")]
		public MistralImageUrl ImageUrl { get; set; }
	}
}
