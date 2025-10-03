using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatSystemWarning
	{
		[JsonProperty("additional_properties")]
		public JObject AdditionalProperties { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("more_info")]
		public string MoreInfo { get; set; }
	}
}
