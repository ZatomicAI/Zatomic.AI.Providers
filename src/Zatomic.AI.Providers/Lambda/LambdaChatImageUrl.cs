using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatImageUrl
	{
		[JsonProperty("url")]
		public string Url { get; set; }
	}
}
