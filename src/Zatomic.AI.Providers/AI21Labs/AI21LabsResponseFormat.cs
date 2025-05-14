using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
