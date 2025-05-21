using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatFileContent : OpenAIChatBaseContent
	{
		[JsonProperty("file")]
		public OpenAIChatFile File { get; set; }
	}
}
