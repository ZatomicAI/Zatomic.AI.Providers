using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatFunctionCall
	{
		[JsonProperty("arguments")]
		public object Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
