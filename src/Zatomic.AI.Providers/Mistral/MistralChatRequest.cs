using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralChatRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<MistralChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("prediction", NullValueHandling = NullValueHandling.Ignore)]
		public MistralChatPrediction Prediction { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("random_seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? RandomSeed { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public MistralChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("safe_prompt", NullValueHandling = NullValueHandling.Ignore)]
		public bool? SafePrompt { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public MistralChatRequest()
		{
			Messages = new List<MistralChatInputMessage>();
		}

		public MistralChatRequest(string model) : this()
		{
			Model = model;
		}

		public MistralChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public MistralChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new MistralChatResponseFormat { Type = responseFormat };
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
			var msg = new MistralChatInputMessage { Role = role };
			msg.Content.Add(new MistralChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl, string imageDetail)
		{
			var msg = new MistralChatInputMessage { Role = role };
			msg.Content.Add(new MistralChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new MistralChatImageUrlContent { Type = "image_url", ImageUrl = new MistralChatImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}
	}
}
