using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatToolChoiceFunction
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
