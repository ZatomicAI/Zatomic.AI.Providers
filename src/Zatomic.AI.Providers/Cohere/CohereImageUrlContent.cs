using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereImageUrlContent : BaseCohereContent
	{
		[JsonProperty("image_url")]
		public CohereImageUrl ImageUrl { get; set; }
	}
}
