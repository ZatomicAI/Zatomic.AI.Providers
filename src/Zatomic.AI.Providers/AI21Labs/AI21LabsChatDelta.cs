using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatDelta
	{
		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
