using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatUrlCitation
	{
		[JsonProperty("end_index")]
		public int EndIndex { get; set; }

		[JsonProperty("start_index")]
		public int StartIndex { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
