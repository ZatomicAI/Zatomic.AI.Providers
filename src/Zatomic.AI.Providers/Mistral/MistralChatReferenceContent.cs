using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatReferenceContent : MistralChatBaseContent
	{
		[JsonProperty("reference_ids")]
		public List<int> ReferenceIds { get; set; }
	}
}
