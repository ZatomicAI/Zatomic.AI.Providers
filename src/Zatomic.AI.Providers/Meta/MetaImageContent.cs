using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaImageContent : BaseMetaContent
	{
		[JsonProperty("image_url")]
		public MetaImageUrl ImageUrl { get; set; }
	}
}
