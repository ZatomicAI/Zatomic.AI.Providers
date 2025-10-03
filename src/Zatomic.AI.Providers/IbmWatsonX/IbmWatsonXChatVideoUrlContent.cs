using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatVideoUrlContent : IbmWatsonXChatBaseContent
	{
		[JsonProperty("data_asset", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatContentDataAsset DataAsset { get; set; }

		[JsonProperty("video_url", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatVideoUrl VideoUrl { get; set; }
	}
}
