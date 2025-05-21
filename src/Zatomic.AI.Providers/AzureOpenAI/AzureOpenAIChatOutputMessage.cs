using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
