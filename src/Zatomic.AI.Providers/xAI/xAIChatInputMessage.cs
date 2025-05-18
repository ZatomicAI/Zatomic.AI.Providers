using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(xAIChatContentListConverter))]
		public List<xAIChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public xAIChatInputMessage()
		{
			Content = new List<xAIChatBaseContent>();
		}
	}
}
