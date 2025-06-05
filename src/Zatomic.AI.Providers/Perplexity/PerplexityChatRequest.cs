using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Perplexity
{
	public class PerplexityChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("messages")]
		public List<PerplexityChatInputMessage> Messages { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("reasoning_effort", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningEffort { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public PerplexityChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("return_images", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ReturnImages { get; set; }

		[JsonProperty("return_related_questions", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ReturnRelatedQuestions { get; set; }

		[JsonProperty("search_after_date_filter", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchAfterDateFilter { get; set; }

		[JsonProperty("search_before_date_filter", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchBeforeDateFilter { get; set; }

		[JsonProperty("search_domain_filter", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> SearchDomainFilter { get; set; }

		[JsonProperty("search_mode", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchMode { get; set; }

		[JsonProperty("search_recency_filter", NullValueHandling = NullValueHandling.Ignore)]
		public string SearchRecencyFilter { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("web_search_options", NullValueHandling = NullValueHandling.Ignore)]
		public PerplexityChatWebSearchOptions WebSearchOptions { get; set; }

		public PerplexityChatRequest()
		{
			Messages = new List<PerplexityChatInputMessage>();
		}

		public PerplexityChatRequest(string model) : this()
		{
			Model = model;
		}

		public PerplexityChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public PerplexityChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new PerplexityChatResponseFormat { Type = responseFormat };
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

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddImageMessage(string role, string content, string imageUrl)
		{
			var msg = new PerplexityChatInputMessage { Role = role };
			msg.Content.Add(new PerplexityChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new PerplexityChatImageUrlContent { Type = "image_url", ImageUrl = new PerplexityChatImageUrl { Url = imageUrl } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new PerplexityChatInputMessage { Role = role };
			msg.Content.Add(new PerplexityChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
