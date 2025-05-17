using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereImageUrlContent : CohereBaseContent
	{
		[JsonProperty("image_url")]
		public CohereImageUrl ImageUrl { get; set; }
	}
}
