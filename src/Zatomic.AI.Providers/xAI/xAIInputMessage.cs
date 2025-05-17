using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(xAIContentListConverter))]
		public List<BasexAIContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public xAIInputMessage()
		{
			Content = new List<BasexAIContent>();
		}
	}
}
