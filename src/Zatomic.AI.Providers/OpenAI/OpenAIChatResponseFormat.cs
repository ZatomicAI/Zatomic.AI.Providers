using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
