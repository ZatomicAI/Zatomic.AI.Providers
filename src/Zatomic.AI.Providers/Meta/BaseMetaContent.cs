using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public abstract class BaseMetaContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
