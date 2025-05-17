using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereTextContent : CohereBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
