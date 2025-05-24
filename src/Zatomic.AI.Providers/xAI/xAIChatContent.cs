using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatContent
	{
		[JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
		public string Detail { get; set; }

		[JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
		public xAIChatImageUrl ImageUrl { get; set; }

		[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
		public string Text { get; set; }

		[JsonProperty("text_file", NullValueHandling = NullValueHandling.Ignore)]
		public string TextFile { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
