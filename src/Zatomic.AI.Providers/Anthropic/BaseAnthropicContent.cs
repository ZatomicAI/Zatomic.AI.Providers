using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public abstract class BaseAnthropicContent
	{
		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
