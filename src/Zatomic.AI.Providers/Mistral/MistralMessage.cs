using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(MistralContentListConverter))]
		public List<BaseMistralContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public MistralMessage()
		{
			Content = new List<BaseMistralContent>();
		}
	}
}
