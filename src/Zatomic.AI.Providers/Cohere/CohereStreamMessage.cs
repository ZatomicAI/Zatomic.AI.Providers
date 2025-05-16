using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereStreamMessage
	{
		[JsonProperty("content")]
		public CohereTextContent Content { get; set; }
	}
}
