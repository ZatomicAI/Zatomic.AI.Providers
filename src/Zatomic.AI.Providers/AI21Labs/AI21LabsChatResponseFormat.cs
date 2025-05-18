using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
