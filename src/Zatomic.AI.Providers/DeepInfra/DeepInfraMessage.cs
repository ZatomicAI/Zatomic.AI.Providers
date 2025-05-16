using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraMessage
	{
		[JsonProperty("content")]
		public List<DeepInfraContent> Content { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		public DeepInfraMessage()
		{
			Content = new List<DeepInfraContent>();
		}
	}
}
