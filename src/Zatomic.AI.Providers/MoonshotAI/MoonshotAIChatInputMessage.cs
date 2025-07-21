using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatInputMessage
	{
		[JsonProperty("content")]
		public List<MoonshotAIChatContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public MoonshotAIChatInputMessage()
		{
			Content = new List<MoonshotAIChatContent>();
		}
	}
}
