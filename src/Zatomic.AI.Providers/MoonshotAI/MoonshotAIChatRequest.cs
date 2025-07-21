using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MoonshotAI
{
	public class MoonshotAIChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<MoonshotAIChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public MoonshotAIChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<MoonshotAIChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public MoonshotAIChatRequest()
		{
			Messages = new List<MoonshotAIChatInputMessage>();
			Tools = new List<MoonshotAIChatTool>();
		}

		public MoonshotAIChatRequest(string model) : this()
		{
			Model = model;
		}

		public MoonshotAIChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public MoonshotAIChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new MoonshotAIChatResponseFormat { Type = responseFormat };
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

		public void AddUserMessage(string content, string imageUrl)
		{
			AddImageMessage("user", content, imageUrl);
		}

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddImageMessage(string role, string content, string imageUrl)
		{
			var msg = new MoonshotAIChatInputMessage { Role = role };
			msg.Content.Add(new MoonshotAIChatContent { Type = "text", Text = content });
			msg.Content.Add(new MoonshotAIChatContent { Type = "image_url", ImageUrl = new MoonshotAIChatImageUrl { Url = imageUrl } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new MoonshotAIChatInputMessage { Role = role };
			msg.Content.Add(new MoonshotAIChatContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
