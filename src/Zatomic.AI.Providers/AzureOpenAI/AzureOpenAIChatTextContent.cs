using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatTextContent : AzureOpenAIChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
