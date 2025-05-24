using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("max_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxTokens { get; set; }

		[JsonProperty("messages")]
		public List<AmazonBedrockChatMessage> Messages { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("stop_sequences", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> StopSequences { get; set; }

		[JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
		public string System { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public AmazonBedrockChatRequest()
		{
			Messages = new List<AmazonBedrockChatMessage>();
		}

		public AmazonBedrockChatRequest(string model) : this()
		{
			Model = model;
		}

		public AmazonBedrockChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public void AddAssistantMessage(string content)
		{
			AddMessage("assistant", content);
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
			var msg = new AmazonBedrockChatMessage { Role = role };
			msg.Content.Add(new AmazonBedrockChatContent { Text = content });

			Messages.Add(msg);
		}
	}
}
