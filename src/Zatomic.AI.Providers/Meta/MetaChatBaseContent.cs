using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public abstract class MetaChatBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
