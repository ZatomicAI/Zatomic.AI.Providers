using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("k", NullValueHandling = NullValueHandling.Ignore)]
		public float? K { get; set; }

		[JsonProperty("logprobs", NullValueHandling = NullValueHandling.Ignore)]
		public bool? LogProbs { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<CohereInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("p", NullValueHandling = NullValueHandling.Ignore)]
		public float? P { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public CohereResponseFormat ResponseFormat { get; set; }

		[JsonProperty("safety_mode", NullValueHandling = NullValueHandling.Ignore)]
		public string SafetyMode { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? Seed { get; set; }

		[JsonProperty("stop_sequences", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> StopSequences { get; set; }

		[JsonProperty("stream")]
		public bool Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		public CohereRequest()
		{
			Messages = new List<CohereInputMessage>();
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
			var msg = new CohereInputMessage { Role = role };
			msg.Content.Add(new CohereTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		private void AddMessage(string role, string content, string imageUrl, string imageDetail)
		{
			var msg = new CohereInputMessage { Role = role };
			msg.Content.Add(new CohereTextContent { Type = "text", Text = content });
			msg.Content.Add(new CohereImageUrlContent { Type = "image_url", ImageUrl = new CohereImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}
	}
}
