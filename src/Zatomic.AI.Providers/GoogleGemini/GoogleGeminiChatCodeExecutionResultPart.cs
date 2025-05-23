using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatCodeExecutionResultPart : GoogleGeminiChatBasePart
	{
		[JsonProperty("outcome")]
		public string Outcome { get; set; }

		[JsonProperty("output")]
		public string Output { get; set; }
	}
}
