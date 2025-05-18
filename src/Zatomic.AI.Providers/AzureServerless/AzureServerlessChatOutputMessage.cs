using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatOutputMessage
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("reasoning_content")]
		public string ReasoningContent { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
