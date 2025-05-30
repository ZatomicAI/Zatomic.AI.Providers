using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Groq
{
	public class GroqChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("messages")]
		public List<GroqChatBaseMessage> Messages { get; set; }

		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("parallel_tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ParallelToolCalls { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("reasoning_effort", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningEffort { get; set; }

		[JsonProperty("reasoning_format", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningFormat { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("search_settings", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatSearchSettings SearchSettings { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Seed { get; set; }

		[JsonProperty("service_tier", NullValueHandling = NullValueHandling.Ignore)]
		public string ServiceTier { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public GroqChatStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public object ToolChoice { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<GroqChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }

		public GroqChatRequest()
		{
			Messages = new List<GroqChatBaseMessage>();
		}

		public GroqChatRequest(string model) : this()
		{
			Model = model;
		}

		public GroqChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public GroqChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new GroqChatResponseFormat { Type = responseFormat };
		}

		public void AddAssistantMessage(string content)
		{
			var msg = new GroqChatAssistantMessage { Content = content, Role = "assistant" };
			Messages.Add(msg);
		}

		public void AddSystemMessage(string content)
		{
			var msg = new GroqChatSystemMessage { Content = content, Role = "system" };
			Messages.Add(msg);
		}

		public void AddUserMessage(string content)
		{
			var msg = new GroqChatUserMessage { Role = "user" };
			msg.Content.Add(new GroqChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}

		public void AddUserMessage(string content, string imageUrl, string imageDetail = null)
		{
			var msg = new GroqChatUserMessage { Role = "user" };
			msg.Content.Add(new GroqChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new GroqChatImageUrlContent { Type = "image_url", ImageUrl = new GroqChatImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}

		public void ClearMessages()
		{
			Messages.Clear();
		}
	}
}
