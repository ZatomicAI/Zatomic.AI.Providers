using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsMessage
	{
		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
