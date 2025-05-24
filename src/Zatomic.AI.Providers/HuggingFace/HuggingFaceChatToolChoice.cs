using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatToolChoice
	{
		[JsonProperty("function")]
		public HuggingFaceChatToolChoiceFunction Function { get; set; }
	}
}
