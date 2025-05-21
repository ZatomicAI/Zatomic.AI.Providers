using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatInputAudio
	{
		[JsonProperty("data")]
		public string Data { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }
	}
}
