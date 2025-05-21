using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
