using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatTextContent : LambdaChatBaseContent
	{
		[JsonProperty("text")]
		public string Text { get; set; }
	}
}
