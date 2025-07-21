using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
