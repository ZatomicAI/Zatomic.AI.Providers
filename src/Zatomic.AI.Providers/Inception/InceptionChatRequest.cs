using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Inception
{
	public class InceptionChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("diffusing", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Diffusing { get; set; }

		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<InceptionChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public InceptionChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public InceptionChatStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<InceptionChatTool> Tools { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public InceptionChatRequest()
		{
			Messages = new List<InceptionChatInputMessage>();
		}

		public InceptionChatRequest(string model) : this()
		{
			Model = model;
		}

		public InceptionChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public InceptionChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new InceptionChatResponseFormat { Type = responseFormat };
		}

		public void AddAssistantMessage(string content)
		{
			AddTextMessage("assistant", content);
		}

		public void AddSystemMessage(string content)
		{
			AddTextMessage("system", content);
		}

		public void AddUserMessage(string content)
		{
			AddTextMessage("user", content);
		}

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new InceptionChatInputMessage { Role = role, Content = content };
			Messages.Add(msg);
		}
	}
}
