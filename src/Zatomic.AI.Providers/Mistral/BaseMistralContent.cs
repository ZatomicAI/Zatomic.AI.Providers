using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public abstract class BaseMistralContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
