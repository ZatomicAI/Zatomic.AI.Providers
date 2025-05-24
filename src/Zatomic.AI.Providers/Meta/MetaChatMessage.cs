using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(MetaChatContentListConverter))]
		public List<MetaChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tool_call_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolCallId { get; set; }

		public MetaChatMessage()
		{
			Content = new List<MetaChatBaseContent>();
		}
	}
}
