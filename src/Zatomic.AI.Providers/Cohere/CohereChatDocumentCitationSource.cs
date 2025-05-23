using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatDocumentCitationSource : CohereChatBaseCitationSource
	{
		[JsonProperty("document")]
		public Dictionary<string, object> Document { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }
	}
}
