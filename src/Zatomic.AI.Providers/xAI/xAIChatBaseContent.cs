using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public abstract class xAIChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
