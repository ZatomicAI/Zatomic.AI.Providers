using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereResponseFormat
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
