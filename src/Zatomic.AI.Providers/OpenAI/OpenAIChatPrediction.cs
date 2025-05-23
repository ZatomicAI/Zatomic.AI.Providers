using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatPrediction
	{
		[JsonProperty("content")]
		public List<OpenAIChatTextContent> Content { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		public OpenAIChatPrediction()
		{
			Content = new List<OpenAIChatTextContent>();
		}
	}
}
