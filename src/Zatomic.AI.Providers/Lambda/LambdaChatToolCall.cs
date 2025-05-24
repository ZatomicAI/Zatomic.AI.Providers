using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatToolCall
	{
		[JsonProperty("function")]
		public LambdaChatToolCallFunction Function { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
