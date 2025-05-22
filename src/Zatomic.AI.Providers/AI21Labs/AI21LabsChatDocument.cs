using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatDocument
	{
		[JsonProperty("content")]
		public string Content { get; set; }

		[JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
		public Dictionary<string, string> Metadata { get; set; }
	}
}
