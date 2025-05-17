using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(MistralContentListConverter))]
		public List<BaseMistralContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public MistralInputMessage()
		{
			Content = new List<BaseMistralContent>();
		}
	}
}
