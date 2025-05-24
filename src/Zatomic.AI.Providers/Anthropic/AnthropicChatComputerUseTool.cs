using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatComputerUseTool : AnthropicChatBaseTool
	{
		[JsonProperty("display_height_px")]
		public int DisplayHeightPx { get; set; }

		[JsonProperty("display_number", NullValueHandling = NullValueHandling.Ignore)]
		public int DisplayNumber { get; set; }

		[JsonProperty("display_width_px")]
		public int DisplayWidthPx { get; set; }
	}
}
