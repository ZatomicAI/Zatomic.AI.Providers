using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
