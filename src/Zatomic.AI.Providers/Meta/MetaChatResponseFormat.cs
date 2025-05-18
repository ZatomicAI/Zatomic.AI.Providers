using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
