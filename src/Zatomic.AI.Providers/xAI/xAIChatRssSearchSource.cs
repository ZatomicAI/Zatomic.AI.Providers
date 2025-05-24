using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatRssSearchSource : xAIChatBaseSearchSource
	{
		[JsonProperty("links")]
		public List<string> Links { get; set; }
	}
}
