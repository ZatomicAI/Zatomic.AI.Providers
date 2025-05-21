using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Lambda
{
	public class LambdaChatRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<LambdaChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public LambdaChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public LambdaChatRequest()
		{
			Messages = new List<LambdaChatInputMessage>();
		}

		public LambdaChatRequest(string model) : this()
		{
			Model = model;
		}

		public LambdaChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public LambdaChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new LambdaChatResponseFormat { Type = responseFormat };
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

		private void AddImageMessage(string role, string content, string imageUrl)
		{
			var msg = new LambdaChatInputMessage { Role = role };
			msg.Content.Add(new LambdaChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new LambdaChatImageUrlContent { Type = "image_url", ImageUrl = new LambdaChatImageUrl { Url = imageUrl } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new LambdaChatInputMessage { Role = role };
			msg.Content.Add(new LambdaChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
