using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatDocumentUrlContent : MistralChatBaseContent
	{
		[JsonProperty("document_name", NullValueHandling = NullValueHandling.Ignore)]
		public string DocumentName { get; set; }

		[JsonProperty("document_url")]
		public string DocumentUrl { get; set; }
	}
}
