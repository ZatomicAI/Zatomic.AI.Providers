using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(MicrosoftFoundryChatContentListConverter))]
		public List<MicrosoftFoundryChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public MicrosoftFoundryChatInputMessage()
		{
			Content = new List<MicrosoftFoundryChatBaseContent>();
		}
	}
}
