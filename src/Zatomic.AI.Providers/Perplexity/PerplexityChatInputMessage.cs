using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(PerplexityChatContentListConverter))]
		public List<PerplexityChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public PerplexityChatInputMessage()
		{
			Content = new List<PerplexityChatBaseContent>();
		}
	}
}
