using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(AzureOpenAIChatContentListConverter))]
		public List<AzureOpenAIChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public AzureOpenAIChatInputMessage()
		{
			Content = new List<AzureOpenAIChatBaseContent>();
		}
	}
}
