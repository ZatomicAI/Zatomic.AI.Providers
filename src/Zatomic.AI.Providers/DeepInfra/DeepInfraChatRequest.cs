using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.DeepInfra
{
	public class DeepInfraChatRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<DeepInfraChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public DeepInfraChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public DeepInfraChatRequest()
		{
			Messages = new List<DeepInfraChatInputMessage>();
		}

		public DeepInfraChatRequest(string model) : this()
		{
			Model = model;
		}

		public DeepInfraChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public DeepInfraChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new DeepInfraChatResponseFormat { Type = responseFormat };
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

		private void AddMessage(string role, string content)
		{
			var msg = new DeepInfraChatInputMessage { Role = role };
			msg.Content.Add(new DeepInfraChatContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
