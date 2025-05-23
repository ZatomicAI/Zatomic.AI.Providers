using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatContentFilterResults
	{
		[JsonProperty("hate")]
		public AzureOpenAIChatContentFilterSeverity Hate { get; set; }

		[JsonProperty("jailbreak")]
		public AzureOpenAIChatContentFilterDetected Jailbreak { get; set; }

		[JsonProperty("protected_material_code")]
		public AzureOpenAIChatContentFilterDetected ProtectedMaterialCode { get; set; }

		[JsonProperty("protected_material_text")]
		public AzureOpenAIChatContentFilterDetected ProtectedMaterialText { get; set; }

		[JsonProperty("self_harm")]
		public AzureOpenAIChatContentFilterSeverity SelfHarm { get; set; }

		[JsonProperty("sexual")]
		public AzureOpenAIChatContentFilterSeverity Sexual { get; set; }

		[JsonProperty("violence")]
		public AzureOpenAIChatContentFilterSeverity Violence { get; set; }
	}
}
