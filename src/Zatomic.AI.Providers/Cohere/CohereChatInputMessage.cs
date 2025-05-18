using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(CohereChatContentListConverter))]
		public List<CohereChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public CohereChatInputMessage()
		{
			Content = new List<CohereChatBaseContent>();
		}
	}
}
