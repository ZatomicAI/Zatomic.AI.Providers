using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public abstract class CohereBaseContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
