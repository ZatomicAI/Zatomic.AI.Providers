using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatAudio
	{
		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("voice")]
		public string Voice { get; set; }
	}
}
