using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicMessage
	{
		[JsonProperty("content")]
		public List<BaseAnthropicContent> Content { get; private set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public AnthropicMessage()
		{
			Content = new List<BaseAnthropicContent>();
		}
	}
}
