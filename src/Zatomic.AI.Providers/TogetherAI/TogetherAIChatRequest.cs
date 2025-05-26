using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.TogetherAI
{
	public class TogetherAIChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("context_length_exceeded_behavior", NullValueHandling = NullValueHandling.Ignore)]
		public string ContentLengthExceededBehavior { get; set; }

		[JsonProperty("echo", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Echo { get; set; }

		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<TogetherAIChatInputMessage> Messages { get; set; }

		[JsonProperty("min_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? MinP { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("repetition_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? RepetitionPenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public TogetherAIChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("safety_model")]
		public string SafetyModel { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public TogetherAIChatRequest()
		{
			Messages = new List<TogetherAIChatInputMessage>();
		}

		public TogetherAIChatRequest(string model) : this()
		{
			Model = model;
		}

		public TogetherAIChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public TogetherAIChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new TogetherAIChatResponseFormat { Type = responseFormat };
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

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddMessage(string role, string content)
		{
			var msg = new TogetherAIChatInputMessage
			{
				Role = role,
				Content = new List<TogetherAIChatBaseContent>
				{
					new TogetherAIChatTextContent { Type = "text", Text = content }
				}
			};

			Messages.Add(msg);
		}
	}
}
