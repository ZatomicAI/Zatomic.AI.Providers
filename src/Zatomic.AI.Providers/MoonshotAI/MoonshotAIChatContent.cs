using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatContent
	{
		[JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
		public MoonshotAIChatImageUrl ImageUrl { get; set; }

		[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
