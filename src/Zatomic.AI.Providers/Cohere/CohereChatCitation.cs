using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatCitation
	{
		[JsonProperty("end")]
		public int End { get; set; }

		[JsonProperty("sources")]
		[JsonConverter(typeof(CohereChatCitationSourcesListConverter))]
		public List<CohereChatBaseCitationSource> Sources { get; set; }

		[JsonProperty("start")]
		public int Start { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		public CohereChatCitation()
		{
			Sources = new List<CohereChatBaseCitationSource>();
		}
	}
}
