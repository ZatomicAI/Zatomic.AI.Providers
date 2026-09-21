using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatContentFilterResults
	{
		[JsonProperty("hate")]
		public MicrosoftFoundryChatContentFilterSeverity Hate { get; set; }

		[JsonProperty("jailbreak")]
		public MicrosoftFoundryChatContentFilterDetected Jailbreak { get; set; }

		[JsonProperty("protected_material_code")]
		public MicrosoftFoundryChatContentFilterDetected ProtectedMaterialCode { get; set; }

		[JsonProperty("protected_material_text")]
		public MicrosoftFoundryChatContentFilterDetected ProtectedMaterialText { get; set; }

		[JsonProperty("self_harm")]
		public MicrosoftFoundryChatContentFilterSeverity SelfHarm { get; set; }

		[JsonProperty("sexual")]
		public MicrosoftFoundryChatContentFilterSeverity Sexual { get; set; }

		[JsonProperty("violence")]
		public MicrosoftFoundryChatContentFilterSeverity Violence { get; set; }
	}
}
