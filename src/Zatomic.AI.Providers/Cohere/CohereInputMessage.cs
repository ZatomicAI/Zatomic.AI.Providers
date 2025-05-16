using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(CohereContentListConverter))]
		public List<BaseCohereContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }
	}
}
