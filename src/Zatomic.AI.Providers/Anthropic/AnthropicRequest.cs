using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicRequest : BaseRequest
	{
		[JsonProperty("max_tokens")]
		public int MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AnthropicMessage> Messages { get; set; }

		[JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicMetadata Metadata { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("stop_sequences", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> StopSequences { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
		public string System { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("thinking", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicThinking Thinking { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public AnthropicRequest()
		{
			Messages = new List<AnthropicMessage>();
		}

		public void AddAssistantMessage(string content)
		{
			AddMessage("assistant", content);
		}

		public void AddUserMessage(string content)
		{
			AddMessage("user", content);
		}

		public void AddUserMessage(string content, string imageUrl)
		{
			AddMessage("user", content, imageUrl);
		}

		public void AddUserMessage(string content, string imageMediaType, string imageBase64Data)
		{
			AddMessage("user", content, imageMediaType, imageBase64Data);
		}

		private void AddMessage(string role, string content)
		{
			var msg = new AnthropicMessage { Role = role };
			msg.Content.Add(new AnthropicTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl)
		{
			var msg = new AnthropicMessage { Role = role };
			msg.Content.Add(new AnthropicTextContent { Type = "text", Text = content });
			msg.Content.Add(new AnthropicImageContent { Type = "image", Source = new AnthropicImageContentSource { Type = "url", Url = imageUrl } });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageMediaType, string imageBase64Data)
		{
			var msg = new AnthropicMessage { Role = role };
			msg.Content.Add(new AnthropicTextContent { Type = "text", Text = content });
			msg.Content.Add(new AnthropicImageContent { Type = "image", Source = new AnthropicImageContentSource { Type = "base64", MediaType = imageMediaType, Data = imageBase64Data } });
			Messages.Add(msg);
		}
	}
}
