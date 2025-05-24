using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatToolCallFunction
	{
		[JsonProperty("arguments")]
		public string Arguments { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
