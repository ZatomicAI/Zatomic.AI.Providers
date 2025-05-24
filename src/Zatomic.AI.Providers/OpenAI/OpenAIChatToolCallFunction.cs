using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
