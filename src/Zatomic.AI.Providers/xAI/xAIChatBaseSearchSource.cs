using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public abstract class xAIChatBaseSearchSource
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
