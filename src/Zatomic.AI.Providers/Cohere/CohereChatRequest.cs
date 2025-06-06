﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Cohere
{
	public class CohereChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("citation_options", NullValueHandling = NullValueHandling.Ignore)]
		public CohereChatCitationOptions CitationOptions { get; set; }

		[JsonProperty("documents", NullValueHandling = NullValueHandling.Ignore)]
		public List<CohereChatDocument> Documents { get; set; }

		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("k", NullValueHandling = NullValueHandling.Ignore)]
		public float? K { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<CohereChatInputMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("p", NullValueHandling = NullValueHandling.Ignore)]
		public float? P { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public CohereChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("safety_mode", NullValueHandling = NullValueHandling.Ignore)]
		public string SafetyMode { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public decimal? Seed { get; set; }

		[JsonProperty("stop_sequences", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> StopSequences { get; set; }

		[JsonProperty("stream")]
		public bool Stream { get; set; }

		[JsonProperty("strict_tools", NullValueHandling = NullValueHandling.Ignore)]
		public bool? StrictTools { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<CohereChatTool> Tools { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolChoice { get; set; }

		public CohereChatRequest()
		{
			Messages = new List<CohereChatInputMessage>();
		}

		public CohereChatRequest(string model) : this()
		{
			Model = model;
		}

		public CohereChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public CohereChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new CohereChatResponseFormat { Type = responseFormat };
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
			var msg = new CohereChatInputMessage { Role = role };
			msg.Content.Add(new CohereChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new CohereChatImageUrlContent { Type = "image_url", ImageUrl = new CohereChatImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new CohereChatInputMessage { Role = role };
			msg.Content.Add(new CohereChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
