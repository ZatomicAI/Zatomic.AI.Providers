using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatOutputMessage
	{
		[JsonProperty("content")]
		public List<CohereChatTextContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public CohereChatOutputMessage()
		{
			Content = new List<CohereChatTextContent>();
		}
	}
}
