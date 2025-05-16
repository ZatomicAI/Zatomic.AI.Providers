using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(MetaContentListConverter))]
		public List<BaseMetaContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public MetaMessage()
		{
			Content = new List<BaseMetaContent>();
		}
	}
}
