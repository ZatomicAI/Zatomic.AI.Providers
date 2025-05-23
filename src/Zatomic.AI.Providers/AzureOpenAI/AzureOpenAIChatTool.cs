using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatTool
	{
		[JsonProperty("function")]
		public AzureOpenAIChatToolFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
