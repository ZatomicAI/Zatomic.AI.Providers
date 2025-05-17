using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
