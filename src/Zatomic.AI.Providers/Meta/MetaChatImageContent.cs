using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatImageContent : MetaChatBaseContent
	{
		[JsonProperty("image_url")]
		public MetaChatImageUrl ImageUrl { get; set; }
	}
}
