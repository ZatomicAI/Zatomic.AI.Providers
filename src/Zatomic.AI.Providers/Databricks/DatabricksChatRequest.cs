using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.Databricks
{
	public class DatabricksChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<DatabricksChatMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("reasoning_effort", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningEffort { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public DatabricksChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public DatabricksChatToolChoice ToolChoice { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<DatabricksChatTool> Tools { get; set; }

		[JsonProperty("top_k", NullValueHandling = NullValueHandling.Ignore)]
		public int? TopK { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }


		public DatabricksChatRequest()
		{
			Messages = new List<DatabricksChatMessage>();
		}

		public DatabricksChatRequest(string model) : this()
		{
			Model = model;
		}

		public DatabricksChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public DatabricksChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new DatabricksChatResponseFormat { Type = responseFormat };
		}

		public void AddAssistantMessage(string content)
		{
			AddChatMessage("assistant", content);
		}

		public void AddSystemMessage(string content)
		{
			AddChatMessage("system", content);
		}

		public void AddUserMessage(string content)
		{
			AddChatMessage("user", content);
		}

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddChatMessage(string role, string content)
		{
			var msg = new DatabricksChatMessage { Role = role, Content = content };
			Messages.Add(msg);
		}
	}
}
