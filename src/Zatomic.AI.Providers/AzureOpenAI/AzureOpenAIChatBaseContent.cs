using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public abstract class AzureOpenAIChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
