using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(AnthropicContentListConverter))]
		public List<BaseAnthropicContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public AnthropicMessage()
		{
			Content = new List<BaseAnthropicContent>();
		}
	}
}
