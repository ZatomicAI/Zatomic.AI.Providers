using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatTextContent : TogetherAIChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
