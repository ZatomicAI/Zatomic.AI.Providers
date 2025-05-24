using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatVideoUrlContent : TogetherAIChatBaseContent
	{
		[JsonProperty("video_url")]
		public TogetherAIChatVideoUrl VideoUrl { get; set; }
	}
}
