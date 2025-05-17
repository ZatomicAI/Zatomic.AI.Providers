using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(CohereContentListConverter))]
		public List<CohereBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public CohereInputMessage()
		{
			Content = new List<CohereBaseContent>();
		}
	}
}
