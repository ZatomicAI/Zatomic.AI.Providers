using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
