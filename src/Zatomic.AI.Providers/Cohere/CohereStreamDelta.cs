using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereStreamDelta
	{
		[JsonProperty("message")]
		public CohereStreamMessage Message { get; set; }

		[JsonProperty("usage")]
		public CohereUsage Usage { get; set; }
	}
}
