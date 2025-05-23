using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatFunctionCallingConfig
	{
		[JsonProperty("allowedFunctionNames", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> AllowedFunctionNames { get; set; }

		[JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
		public string Mode { get; set; }
	}
}
