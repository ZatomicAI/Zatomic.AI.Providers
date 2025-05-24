using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public abstract class CohereChatBaseCitationSource
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
