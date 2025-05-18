using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
