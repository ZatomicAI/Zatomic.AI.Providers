using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
