using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatToolCitationSource : CohereChatBaseCitationSource
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("tool_output")]
		public Dictionary<string, object> ToolOutput { get; set; }
	}
}
