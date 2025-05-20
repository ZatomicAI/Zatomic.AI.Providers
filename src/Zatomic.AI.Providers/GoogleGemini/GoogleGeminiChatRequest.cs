using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatRequest : BaseRequest
	{
		[JsonProperty("contents")]
		public List<GoogleGeminiChatContent> Contents { get; set; }

		[JsonProperty("generationConfig", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatGenerationConfig GenerationConfig { get; set; }

		[JsonProperty("systemInstruction", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatSystemInstruction SystemInstruction { get; set; }

		public GoogleGeminiChatRequest()
		{
			Contents = new List<GoogleGeminiChatContent>();
		}

		public GoogleGeminiChatRequest(float temperature) : this()
		{
			if (GenerationConfig == null)
			{
				GenerationConfig = new GoogleGeminiChatGenerationConfig { Temperature = temperature };
			}
			else
			{
				GenerationConfig.Temperature = temperature;
			}
		}

		public GoogleGeminiChatRequest(float temperature, string responseMimeType) : this(temperature)
		{
			GenerationConfig = new GoogleGeminiChatGenerationConfig { ResponseMimeType = responseMimeType };
		}

		public void AddModelMessage(string content)
		{
			AddMessage("model", content);
		}

		public void AddSystemMessage(string content)
		{
			SystemInstruction = new GoogleGeminiChatSystemInstruction();
			SystemInstruction.Parts.Add(new GoogleGeminiChatTextPart { Text = content });
		}

		public void AddUserMessage(string content)
		{
			AddMessage("user", content);
		}

		public void AddUserMessage(string content, string mimeType, string data)
		{
			AddMessage("user", content, mimeType, data);
		}

		private void AddMessage(string role, string content)
		{
			var contentObj = new GoogleGeminiChatContent { Role = role };
			contentObj.Parts.Add(new GoogleGeminiChatTextPart { Type = "text", Text = content });
			Contents.Add(contentObj);
		}

		private void AddMessage(string role, string content, string mimeType, string data)
		{
			var contentObj = new GoogleGeminiChatContent { Role = role };
			contentObj.Parts.Add(new GoogleGeminiChatTextPart { Type = "text", Text = content });
			contentObj.Parts.Add(new GoogleGeminiChatInlineDataPart { Type = "inlineData", MimeType = mimeType, Data = data });
			Contents.Add(contentObj);
		}
	}
}
