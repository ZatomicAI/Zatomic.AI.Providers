using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.HuggingFace
{
	public class HuggingFaceChatRequest : BaseRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<HuggingFaceChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(HuggingFaceChatResponseFormatConverter))]
		public HuggingFaceChatBaseResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public HuggingFaceChatStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public object ToolChoice { get; set; }

		[JsonProperty("tool_prompt", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolPrompt { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<HuggingFaceChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public HuggingFaceChatRequest()
		{
			Messages = new List<HuggingFaceChatInputMessage>();
		}

		public HuggingFaceChatRequest(string model) : this()
		{
			Model = model;
		}

		public HuggingFaceChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
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
			var msg = new HuggingFaceChatInputMessage
			{
				Role = role,
				Content = new List<HuggingFaceChatBaseContent>
				{
					new HuggingFaceChatTextContent { Type = "text", Text = content },
					new HuggingFaceChatImageUrlContent { Type = "image_url", ImageUrl = new HuggingFaceChatImageUrl { Url = imageUrl } }
				}
			};

			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new HuggingFaceChatInputMessage
			{
				Role = role,
				Content = new List<HuggingFaceChatBaseContent>
				{
					new HuggingFaceChatTextContent { Type = "text", Text = content }
				}
			};

			Messages.Add(msg);
		}
	}
}
