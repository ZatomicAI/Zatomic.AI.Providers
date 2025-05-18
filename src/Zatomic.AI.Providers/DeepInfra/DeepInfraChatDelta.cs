using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
