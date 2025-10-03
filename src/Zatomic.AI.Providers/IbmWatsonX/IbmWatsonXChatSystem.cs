using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatSystem
	{
		[JsonProperty("warnings")]
		public List<IbmWatsonXChatSystemWarning> Warnings { get; set; }

		public IbmWatsonXChatSystem()
		{
			Warnings = new List<IbmWatsonXChatSystemWarning>();
		}
	}
}
