using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatInputAudio
	{
		[JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
		public string Data { get; set; }

		[JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
		public string Format { get; set; }
	}
}
