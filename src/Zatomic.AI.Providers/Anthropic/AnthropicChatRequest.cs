using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Anthropic
{
	public class AnthropicChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("max_tokens")]
		public int MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AnthropicChatMessage> Messages { get; set; }

		[JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicChatMetadata Metadata { get; set; }

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
		public AnthropicChatThinking Thinking { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public AnthropicChatToolChoice ToolChoice { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(AnthropicChatToolsListConverter))]
		public List<AnthropicChatBaseTool> Tools { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public AnthropicChatRequest()
		{
			Messages = new List<AnthropicChatMessage>();
		}

		public AnthropicChatRequest(string model, int maxTokens) : this()
		{
			Model = model;
			MaxTokens = maxTokens;
		}

		public AnthropicChatRequest(string model, int maxTokens, float temperature) : this(model, maxTokens)
		{
			Temperature = temperature;
		}

		public void AddAssistantMessage(string content)
		{
			AddTextMessage("assistant", content);
		}

		public void AddUserMessage(string content)
		{
			AddTextMessage("user", content);
		}

		public void AddUserMessage(string content, string imageUrl)
		{
			AddImageMessage("user", content, imageUrl);
		}

		public void AddUserMessage(string content, string imageMediaType, string imageBase64Data)
		{
			AddImageMessage("user", content, imageMediaType, imageBase64Data);
		}

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddImageMessage(string role, string content, string imageUrl)
		{
			var msg = new AnthropicChatMessage { Role = role };
			msg.Content.Add(new AnthropicChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new AnthropicChatImageContent { Type = "image", Source = new AnthropicChatImageContentSource { Type = "url", Url = imageUrl } });
			Messages.Add(msg);
		}

		private void AddImageMessage(string role, string content, string imageMediaType, string imageBase64Data)
		{
			var msg = new AnthropicChatMessage { Role = role };
			msg.Content.Add(new AnthropicChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new AnthropicChatImageContent { Type = "image", Source = new AnthropicChatImageContentSource { Type = "base64", MediaType = imageMediaType, Data = imageBase64Data } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new AnthropicChatMessage { Role = role };
			msg.Content.Add(new AnthropicChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
