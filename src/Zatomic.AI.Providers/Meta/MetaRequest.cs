using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Meta
{
	public class MetaRequest : BaseRequest
	{
		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("messages")]
		public List<MetaMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("repetition_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? RepetitionPenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public MetaResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public MetaRequest()
		{
			Messages = new List<MetaMessage>();
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
			var msg = new MetaMessage { Role = role };
			msg.Content.Add(new MetaTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl)
		{
			var msg = new MetaMessage { Role = role };
			msg.Content.Add(new MetaTextContent { Type = "text", Text = content });
			msg.Content.Add(new MetaImageContent { Type = "image", ImageUrl = new MetaImageUrl { Url = imageUrl } });
			Messages.Add(msg);
		}
	}
}
