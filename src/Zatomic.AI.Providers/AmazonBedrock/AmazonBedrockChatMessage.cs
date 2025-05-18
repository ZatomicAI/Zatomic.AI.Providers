using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatMessage
	{
		[JsonProperty("content")]
		public List<AmazonBedrockChatContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public AmazonBedrockChatMessage()
		{
			Content = new List<AmazonBedrockChatContent>();
		}
	}
}
