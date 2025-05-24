using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatSearchParameters
	{
		[JsonProperty("from_date", NullValueHandling = NullValueHandling.Ignore)]
		public string FromDate { get; set; }

		[JsonProperty("max_search_results", NullValueHandling = NullValueHandling.Ignore)]
		public int MaxSearchResults { get; set; }

		[JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
		public string Mode { get; set; }

		[JsonProperty("return_citations", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ReturnCitations { get; set; }

		[JsonProperty("sources", NullValueHandling = NullValueHandling.Ignore)]
		public List<xAIChatBaseSearchSource> Sources { get; set; }

		[JsonProperty("to_date", NullValueHandling = NullValueHandling.Ignore)]
		public string ToDate { get; set; }
	}
}
