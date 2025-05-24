using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureOpenAI
{
	public class AzureOpenAIChatRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AzureOpenAIChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("parallel_tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ParallelToolCalls { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public AzureOpenAIChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public long? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public AzureOpenAIChatStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public object ToolChoice { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<AzureOpenAIChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }

		public AzureOpenAIChatRequest()
		{
			Messages = new List<AzureOpenAIChatInputMessage>();
		}

		public AzureOpenAIChatRequest(string model) : this()
		{
			Model = model;
		}

		public AzureOpenAIChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public AzureOpenAIChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new AzureOpenAIChatResponseFormat { Type = responseFormat };
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

		public void AddUserMessage(string content, string imageUrl, string imageDetail = null)
		{
			AddImageMessage("user", content, imageUrl, imageDetail);
		}

		private void AddImageMessage(string role, string content, string imageUrl, string imageDetail = null)
		{
			var msg = new AzureOpenAIChatInputMessage { Role = role };
			msg.Content.Add(new AzureOpenAIChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new AzureOpenAIChatImageUrlContent { Type = "image_url", ImageUrl = new AzureOpenAIChatImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new AzureOpenAIChatInputMessage { Role = role };
			msg.Content.Add(new AzureOpenAIChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
