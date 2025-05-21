using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatFile
	{
		[JsonProperty("file_data", NullValueHandling = NullValueHandling.Ignore)]
		public string FileData { get; set; }

		[JsonProperty("file_id", NullValueHandling = NullValueHandling.Ignore)]
		public string FileId { get; set; }

		[JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
		public string FileName { get; set; }
	}
}
