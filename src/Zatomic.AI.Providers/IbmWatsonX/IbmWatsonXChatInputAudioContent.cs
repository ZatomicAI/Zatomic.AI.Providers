using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatInputAudioContent : IbmWatsonXChatBaseContent
	{
		[JsonProperty("data_asset", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatContentDataAsset DataAsset { get; set; }

		[JsonProperty("input_audio", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatInputAudio InputAudio { get; set; }
	}
}
