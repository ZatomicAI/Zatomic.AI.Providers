using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatFunctionCall
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
