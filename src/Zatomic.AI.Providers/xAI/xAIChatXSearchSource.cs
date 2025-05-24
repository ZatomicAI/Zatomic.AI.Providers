using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatXSearchSource : xAIChatBaseSearchSource
	{
		[JsonProperty("x_handles", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> XHandles { get; set; }
	}
}
