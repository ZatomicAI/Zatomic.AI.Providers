using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public abstract class OpenAIChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
