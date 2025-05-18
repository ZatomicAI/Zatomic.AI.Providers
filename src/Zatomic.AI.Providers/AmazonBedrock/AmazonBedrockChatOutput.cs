using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatOutput
	{
		[JsonProperty("message")]
		public AmazonBedrockChatMessage Message { get; set; }
	}
}
