using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
