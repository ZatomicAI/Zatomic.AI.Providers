using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatInputMessage
	{
		[JsonProperty("content")]
		[JsonConverter(typeof(LambdaChatContentListConverter))]
		public List<LambdaChatBaseContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public LambdaChatInputMessage()
		{
			Content = new List<LambdaChatBaseContent>();
		}
	}
}
