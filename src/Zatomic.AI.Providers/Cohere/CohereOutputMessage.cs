using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereOutputMessage
	{
		[JsonProperty("content")]
		public List<CohereTextContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public CohereOutputMessage()
		{
			Content = new List<CohereTextContent>();
		}
	}
}
