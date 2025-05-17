using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public abstract class BasexAIContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
