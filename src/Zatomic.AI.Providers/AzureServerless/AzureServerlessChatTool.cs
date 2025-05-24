using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatTool
	{
		[JsonProperty("function")]
		public AzureServerlessChatFunctionCall Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
