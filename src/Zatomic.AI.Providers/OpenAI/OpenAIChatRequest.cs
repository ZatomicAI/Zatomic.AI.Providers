using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.OpenAI
{
	public class OpenAIChatRequest : BaseRequest
	{
		[JsonProperty("audio", NullValueHandling = NullValueHandling.Ignore)]
		public OpenAIChatAudio Audio { get; set; }

		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonProperty("messages")]
		public List<OpenAIChatInputMessage> Messages { get; set; }

		[JsonProperty("modalities", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Modalities { get; set; }

		[JsonProperty("model")]
		public string Model { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("parallel_tool_calls", NullValueHandling = NullValueHandling.Ignore)]
		public bool? ParallelToolCalls { get; set; }

		[JsonProperty("prediction", NullValueHandling = NullValueHandling.Ignore)]
		public OpenAIChatPrediction Prediction { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("reasoning_effort", NullValueHandling = NullValueHandling.Ignore)]
		public string ReasoningEffort { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public OpenAIChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public long? Seed { get; set; }

		[JsonProperty("service_tier", NullValueHandling = NullValueHandling.Ignore)]
		public string ServiceTier { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Stream { get; set; }

		[JsonProperty("store", NullValueHandling = NullValueHandling.Ignore)]
		public bool? Store { get; set; }

		[JsonProperty("stream_options", NullValueHandling = NullValueHandling.Ignore)]
		public OpenAIChatStreamOptions StreamOptions { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public object ToolChoice { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<OpenAIChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		[JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
		public string User { get; set; }

		[JsonProperty("web_search_options", NullValueHandling = NullValueHandling.Ignore)]
		public OpenAIChatWebSearchOptions WebSearchOptions { get; set; }

		public OpenAIChatRequest()
		{
			Messages = new List<OpenAIChatInputMessage>();
		}

		public OpenAIChatRequest(string model) : this()
		{
			Model = model;
		}

		public OpenAIChatRequest(string model, float temperature) : this(model)
		{
			Temperature = temperature;
		}

		public OpenAIChatRequest(string model, float temperature, string responseFormat) : this(model, temperature)
		{
			ResponseFormat = new OpenAIChatResponseFormat { Type = responseFormat };
		}

		public void AddAssistantMessage(string content)
		{
			AddTextMessage("assistant", content);
		}

		public void AddDeveloperMessage(string content)
		{
			AddTextMessage("developer", content);
		}

		public void AddSystemMessage(string content)
		{
			AddTextMessage("system", content);
		}

		public void AddUserMessage(string content)
		{
			AddTextMessage("user", content);
		}

		public void AddUserMessage(string content, string audioData, OpenAIChatInputAudioFormat audioFormat)
		{
			AddAudioMessage("user", content, audioData, audioFormat);
		}

		public void AddUserMessage(string content, string fileData, string fileId, string fileName)
		{
			AddFileMessage("user", content, fileData, fileId, fileName);
		}

		public void AddUserMessage(string content, string imageUrl, string imageDetail = null)
		{
			AddImageMessage("user", content, imageUrl, imageDetail);
		}

		private void AddAudioMessage(string role, string content, string audioData, OpenAIChatInputAudioFormat audioFormat)
		{
			var msg = new OpenAIChatInputMessage { Role = role };
			msg.Content.Add(new OpenAIChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new OpenAIChatInputAudioContent { Type = "input_audio", InputAudio = new OpenAIChatInputAudio { Data = audioData, Format = audioFormat.ToString() } });
			Messages.Add(msg);
		}

		private void AddFileMessage(string role, string content, string fileData, string fileId, string fileName)
		{
			var msg = new OpenAIChatInputMessage { Role = role };
			msg.Content.Add(new OpenAIChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new OpenAIChatFileContent { Type = "file", File = new OpenAIChatFile { FileData = fileData, FileId = fileId, FileName = fileName } });
			Messages.Add(msg);
		}

		private void AddImageMessage(string role, string content, string imageUrl, string imageDetail = null)
		{
			var msg = new OpenAIChatInputMessage { Role = role };
			msg.Content.Add(new OpenAIChatTextContent { Type = "text", Text = content });
			msg.Content.Add(new OpenAIChatImageUrlContent { Type = "image_url", ImageUrl = new OpenAIChatImageUrl { Url = imageUrl, Detail = imageDetail } });
			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new OpenAIChatInputMessage { Role = role };
			msg.Content.Add(new OpenAIChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
