using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatTool
	{
		[JsonProperty("function")]
		public AI21LabsChatFunction Function { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
