using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereTextContent : BaseCohereContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
