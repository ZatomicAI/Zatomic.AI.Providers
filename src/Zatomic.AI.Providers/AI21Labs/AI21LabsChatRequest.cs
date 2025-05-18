using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AI21Labs
{
	public class AI21LabsChatRequest : BaseRequest
	{
		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AI21LabsChatMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public AI21LabsChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public AI21LabsChatRequest()
		{
			Messages = new List<AI21LabsChatMessage>();
		}

		public AI21LabsChatRequest(string model) : this()
		{
			Model = model;
		}

		public AI21LabsChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public AI21LabsChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new AI21LabsChatResponseFormat { Type = responseFormat };
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
			Messages.Add(new AI21LabsChatMessage { Role = role, Content = content });
		}
	}
}
