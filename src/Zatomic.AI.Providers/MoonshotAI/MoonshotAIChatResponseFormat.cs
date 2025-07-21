using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
