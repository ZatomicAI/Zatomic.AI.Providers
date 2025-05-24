using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatToolChoiceFunction
	{
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
