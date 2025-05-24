using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatToolChoiceTool
	{
		[JsonProperty("function")]
		public AzureOpenAIChatToolChoiceFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
