using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraInputMessage
	{
		[JsonProperty("content")]
		public List<DeepInfraContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public DeepInfraInputMessage()
		{
			Content = new List<DeepInfraContent>();
		}
	}
}
