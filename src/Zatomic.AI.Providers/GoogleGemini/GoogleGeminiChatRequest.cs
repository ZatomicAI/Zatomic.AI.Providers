using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.GoogleGemini
{
    public class GoogleGeminiChatRequest : BaseRequest
	{
		[JsonProperty("cachedContent", NullValueHandling = NullValueHandling.Ignore)]
		public string CachedContent { get; set; }

		[JsonProperty("contents")]
		public List<GoogleGeminiChatContent> Contents { get; set; }

		[JsonProperty("generationConfig", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatGenerationConfig GenerationConfig { get; set; }

		[JsonIgnore]
		public string Model { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<GoogleGeminiChatSafetySetting> SafetySettings { get; set; }

		[JsonProperty("systemInstruction", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatSystemInstruction SystemInstruction { get; set; }

		[JsonProperty("toolConfig", NullValueHandling = NullValueHandling.Ignore)]
		public GoogleGeminiChatToolConfig ToolConfig { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<GoogleGeminiChatTool> Tools { get; set; }

		public GoogleGeminiChatRequest()
		{
			Contents = new List<GoogleGeminiChatContent>();
		}

		public GoogleGeminiChatRequest(string model) : this()
		{
			Model = model;
		}

		public GoogleGeminiChatRequest(string model, float temperature) : this(model)
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

		public GoogleGeminiChatRequest(string model, float temperature, string responseMimeType) : this(model, temperature)
		{
			GenerationConfig = new GoogleGeminiChatGenerationConfig { ResponseMimeType = responseMimeType };
		}

		public void AddModelMessage(string content)
		{
			AddTextMessage("model", content);
		}

		public void AddSystemMessage(string content)
		{
			SystemInstruction = new GoogleGeminiChatSystemInstruction();
			SystemInstruction.Parts.Add(new GoogleGeminiChatTextPart { Text = content });
		}

		public void AddUserMessage(string content)
		{
			AddTextMessage("user", content);
		}

		public void AddUserMessage(string content, string mimeType, string data)
		{
			AddImageMessage("user", content, mimeType, data);
		}

		private void AddImageMessage(string role, string content, string mimeType, string data)
		{
			var contentObj = new GoogleGeminiChatContent { Role = role };
			contentObj.Parts.Add(new GoogleGeminiChatTextPart { Text = content });
			contentObj.Parts.Add(new GoogleGeminiChatInlineDataPart { MimeType = mimeType, Data = data });
			Contents.Add(contentObj);
		}

		private void AddTextMessage(string role, string content)
		{
			var contentObj = new GoogleGeminiChatContent { Role = role };
			contentObj.Parts.Add(new GoogleGeminiChatTextPart { Text = content });
			Contents.Add(contentObj);
		}
	}
}
