using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatVideoUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
