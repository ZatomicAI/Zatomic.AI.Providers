using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaImageContent : MetaBaseContent
	{
		[JsonProperty("image_url")]
		public MetaImageUrl ImageUrl { get; set; }
	}
}
