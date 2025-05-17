using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public abstract class xAIBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
