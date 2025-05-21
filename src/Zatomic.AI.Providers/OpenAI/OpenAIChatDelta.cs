using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
