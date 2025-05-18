using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaChatRequest : BaseRequest
	{
		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("messages")]
		public List<MetaChatMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("repetition_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? RepetitionPenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public MetaChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public MetaChatRequest()
		{
			Messages = new List<MetaChatMessage>();
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

		public void AddUserMessage(string content, string imageUrl)
		{
			AddMessage("user", content, imageUrl);
		}

		private void AddMessage(string role, string content)
		{
			var msg = new MetaChatMessage { Role = role };
			msg.Content.Add(new MetaChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl)
		{
			var msg = new MetaChatMessage { Role = role };
			msg.Content.Add(new MetaChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new MetaChatImageContent { Type = "image", ImageUrl = new MetaChatImageUrl { Url = imageUrl } });
			Messages.Add(msg);
		}
	}
}
