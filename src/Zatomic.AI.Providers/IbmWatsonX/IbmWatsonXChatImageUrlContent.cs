using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatImageUrlContent : IbmWatsonXChatBaseContent
	{
		[JsonProperty("data_asset", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatContentDataAsset DataAsset { get; set; }

		[JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatImageUrl ImageUrl { get; set; }
	}
}
