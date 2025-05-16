using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public abstract class BaseCohereContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
