using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatImageUrlContent : LambdaChatBaseContent
	{
		[JsonProperty("image_url")]
		public LambdaChatImageUrl ImageUrl { get; set; }
	}
}
