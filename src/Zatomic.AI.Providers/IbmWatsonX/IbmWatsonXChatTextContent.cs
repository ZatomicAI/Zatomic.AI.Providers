using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatTextContent : IbmWatsonXChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
