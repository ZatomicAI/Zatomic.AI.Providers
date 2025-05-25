using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.FireworksAI
{
	public class FireworksAIChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("context_length_exceeded_behavior", NullValueHandling = NullValueHandling.Ignore)]
		public string ContentLengthExceededBehavior { get; set; }

		[JsonProperty("ignore_eos", NullValueHandling = NullValueHandling.Ignore)]
		public bool? IgnoreEos { get; set; }

		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<FireworksAIChatInputMessage> Messages { get; set; }

		[JsonProperty("mirostat_lr", NullValueHandling = NullValueHandling.Ignore)]
		public float? MirostatLearningRate { get; set; }

		[JsonProperty("mirostat_target", NullValueHandling = NullValueHandling.Ignore)]
		public float? MirostatTarget { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("prompt_truncate_len", NullValueHandling = NullValueHandling.Ignore)]
		public int? PromptTruncateLength { get; set; }

		[JsonProperty("reasoning_effort", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningEffort { get; set; }

		[JsonProperty("repetition_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? RepetitionPenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public FireworksAIChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<FireworksAIChatTool> Tools { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }

		public FireworksAIChatRequest()
		{
			Messages = new List<FireworksAIChatInputMessage>();
		}

		public FireworksAIChatRequest(string model) : this()
		{
			Model = model;
		}

		public FireworksAIChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public FireworksAIChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new FireworksAIChatResponseFormat { Type = responseFormat };
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
			Messages.Add(new FireworksAIChatInputMessage { Role = role, Content = content });
		}
	}
}
