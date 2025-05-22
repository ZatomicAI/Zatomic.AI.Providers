using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatFunctionCall
	{
		[JsonProperty("arguments")]
		public JObject Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
