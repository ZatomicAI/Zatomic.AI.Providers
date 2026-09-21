using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.MicrosoftFoundry
{
	public class MicrosoftFoundryChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("messages")]
		public List<MicrosoftFoundryChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("parallel_tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ParallelToolCalls { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public MicrosoftFoundryChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public MicrosoftFoundryChatStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public object ToolChoice { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<MicrosoftFoundryChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }

		public MicrosoftFoundryChatRequest()
		{
			Messages = new List<MicrosoftFoundryChatInputMessage>();
		}

		public MicrosoftFoundryChatRequest(string model) : this()
		{
			Model = model;
		}

		public MicrosoftFoundryChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public MicrosoftFoundryChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new MicrosoftFoundryChatResponseFormat { Type = responseFormat };
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

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddImageMessage(string role, string content, string imageUrl, string imageDetail = null)
		{
			var msg = new MicrosoftFoundryChatInputMessage { Role = role };
			msg.Content.Add(new MicrosoftFoundryChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new MicrosoftFoundryChatImageUrlContent { Type = "image_url", ImageUrl = new MicrosoftFoundryChatImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new MicrosoftFoundryChatInputMessage { Role = role };
			msg.Content.Add(new MicrosoftFoundryChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
