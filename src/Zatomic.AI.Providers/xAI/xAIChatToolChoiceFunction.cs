using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIChatToolChoiceFunction
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
