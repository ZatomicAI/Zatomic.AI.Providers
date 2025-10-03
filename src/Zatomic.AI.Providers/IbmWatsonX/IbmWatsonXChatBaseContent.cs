using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public abstract class IbmWatsonXChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
