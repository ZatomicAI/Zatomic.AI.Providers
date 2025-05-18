using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatInputMessage
	{
		[JsonProperty("content")]
		public List<DeepInfraChatContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public DeepInfraChatInputMessage()
		{
			Content = new List<DeepInfraChatContent>();
		}
	}
}
