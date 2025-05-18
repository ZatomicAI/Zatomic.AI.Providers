using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public abstract class CohereChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
