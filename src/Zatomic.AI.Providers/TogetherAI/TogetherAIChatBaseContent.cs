using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public abstract class TogetherAIChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
