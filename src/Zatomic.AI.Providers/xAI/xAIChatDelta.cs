using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
