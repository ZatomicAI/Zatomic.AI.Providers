using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
