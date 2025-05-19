using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(HuggingFaceChatContentListConverter))]
		public List<HuggingFaceChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public HuggingFaceChatInputMessage()
		{
			Content = new List<HuggingFaceChatBaseContent>();
		}
	}
}
