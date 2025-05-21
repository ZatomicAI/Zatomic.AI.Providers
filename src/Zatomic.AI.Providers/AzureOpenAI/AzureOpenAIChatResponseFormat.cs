using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
