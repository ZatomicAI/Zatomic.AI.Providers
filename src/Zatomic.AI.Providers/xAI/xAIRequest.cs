using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.xAI
{
	public class xAIRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("messages")]
		public List<xAIInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("reasoning_effort", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningEffort { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public xAIResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public xAIStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }

		public xAIRequest()
		{
			Messages = new List<xAIInputMessage>();
		}

		public void AddAssistantMessage(string content)
		{
			AddMessage("assistant", content);
		}

		public void AddSystemMessage(string content)
		{
			AddMessage("system", content);
		}

		public void AddUserMessage(string content)
		{
			AddMessage("user", content);
		}

		public void AddUserMessage(string content, string imageUrl, string imageDetail)
		{
			AddMessage("user", content, imageUrl, imageDetail);
		}

		private void AddMessage(string role, string content)
		{
			var msg = new xAIInputMessage { Role = role };
			msg.Content.Add(new xAITextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl, string imageDetail)
		{
			var msg = new xAIInputMessage { Role = role };
			msg.Content.Add(new xAITextContent { Type = "text", Text = content });
			msg.Content.Add(new xAIImageUrlContent { Type = "image_url", ImageUrl = new xAIImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}
	}
}
