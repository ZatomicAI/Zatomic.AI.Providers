using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatInputAudioContent : OpenAIChatBaseContent
	{
		[JsonProperty("input_audio")]
		public OpenAIChatInputAudio InputAudio { get; set; }
	}
}
