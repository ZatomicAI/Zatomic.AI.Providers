using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
