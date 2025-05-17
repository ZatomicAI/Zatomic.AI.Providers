using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
