using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
