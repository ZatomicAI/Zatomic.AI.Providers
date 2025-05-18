using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public abstract class LambdaChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
