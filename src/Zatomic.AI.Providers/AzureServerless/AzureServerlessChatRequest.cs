using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AzureServerless
{
	public class AzureServerlessChatRequest : BaseRequest
	{
		[JsonIgnore]
		public string Endpoint { get; set; }

		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AzureServerlessChatInputMessage> Messages { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public AzureServerlessChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? Seed { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public AzureServerlessChatRequest()
		{
			Messages = new List<AzureServerlessChatInputMessage>();
		}

		public AzureServerlessChatRequest(string endpoint) : this()
		{
			Endpoint = endpoint;
		}

		public AzureServerlessChatRequest(string endpoint, float temperature) : this(endpoint)
		{
			Temperature = temperature;
		}

		public AzureServerlessChatRequest(string endpoint, float temperature, string responseFormat) : this(endpoint, temperature)
		{
			ResponseFormat = new AzureServerlessChatResponseFormat { Type = responseFormat };
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
			var msg = new AzureServerlessChatInputMessage { Role = role, Content = content };
			Messages.Add(msg);
		}
	}
}
