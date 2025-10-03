using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
