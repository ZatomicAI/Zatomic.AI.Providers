using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
