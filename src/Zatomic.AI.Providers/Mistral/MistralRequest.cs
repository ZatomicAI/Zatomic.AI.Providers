using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Mistral
{
	public class MistralRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<MistralMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("prediction", NullValueHandling = NullValueHandling.Ignore)]
		public MistralPrediction Prediction { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("random_seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? RandomSeed { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public MistralResponseFormat ResponseFormat { get; set; }

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

		public MistralRequest()
		{
			Messages = new List<MistralMessage>();
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
			var msg = new MistralMessage { Role = role };
			msg.Content.Add(new MistralTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl, string imageDetail)
		{
			var msg = new MistralMessage { Role = role };
			msg.Content.Add(new MistralTextContent { Type = "text", Text = content });
			msg.Content.Add(new MistralImageUrlContent { Type = "image_url", ImageUrl = new MistralImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}
	}
}
