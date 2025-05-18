using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
