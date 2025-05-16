using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
