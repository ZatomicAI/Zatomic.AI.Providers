using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zatomic.AI.Providers.IbmWatsonX
{
	public class IbmWatsonXChatRequest : BaseRequest, IChatRequest
	{
		[JsonProperty("frequency_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? FrequencyPenalty { get; set; }

		[JsonProperty("max_completion_tokens", NullValueHandling = NullValueHandling.Ignore)]
		public int? MaxCompletionTokens { get; set; }

		[JsonProperty("messages")]
		public List<IbmWatsonXChatInputMessage> Messages { get; set; }

		[JsonProperty("model_id")]
		public string ModelId { get; set; }

		[JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
		public int? N { get; set; }

		[JsonProperty("presence_penalty", NullValueHandling = NullValueHandling.Ignore)]
		public float? PresencePenalty { get; set; }

		[JsonProperty("project_id", NullValueHandling = NullValueHandling.Ignore)]
		public string ProjectId { get; set; }

		[JsonProperty("response_format", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatResponseFormat ResponseFormat { get; set; }

		[JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
		public int? Seed { get; set; }

		[JsonProperty("space_id", NullValueHandling = NullValueHandling.Ignore)]
		public string SpaceId { get; set; }

		[JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
		public List<string> Stop { get; set; }

		[JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
		public float? Temperature { get; set; }

		[JsonProperty("time_limit", NullValueHandling = NullValueHandling.Ignore)]
		public int? TimeLimit { get; set; }

		[JsonProperty("tool_choice", NullValueHandling = NullValueHandling.Ignore)]
		public IbmWatsonXChatToolChoice ToolChoice { get; set; }

		[JsonProperty("tool_choice_option", NullValueHandling = NullValueHandling.Ignore)]
		public string ToolChoiceOption { get; set; }

		[JsonProperty("tools", NullValueHandling = NullValueHandling.Ignore)]
		public List<IbmWatsonXChatTool> Tools { get; set; }

		[JsonProperty("top_p", NullValueHandling = NullValueHandling.Ignore)]
		public float? TopP { get; set; }

		public IbmWatsonXChatRequest()
		{
			Messages = new List<IbmWatsonXChatInputMessage>();
		}

		public IbmWatsonXChatRequest(string projectId, string modelId) : this()
		{
			ProjectId = projectId;
			ModelId = modelId;
		}

		public IbmWatsonXChatRequest(string projectId, string modelId, float temperature) : this(projectId, modelId)
		{
			Temperature = temperature;
		}

		public IbmWatsonXChatRequest(string projectId, string modelId, float temperature, string responseFormat) : this(projectId, modelId, temperature)
		{
			ResponseFormat = new IbmWatsonXChatResponseFormat { Type = responseFormat };
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

		public void AddUserMessage(string content, string audioData, IbmWatsonXChatInputAudioFormat audioFormat)
		{
			AddAudioMessage("user", content, audioData, audioFormat);
		}
		
		public void AddUserMessage(string content, string imageUrl, string imageDetail = null, string dataAssetId = null)
		{
			AddImageMessage("user", content, imageUrl, imageDetail, dataAssetId);
		}

		public void AddUserMessage(string content, string videoUrl, string dataAssetId = null)
		{
			AddVideoMessage("user", content, videoUrl, dataAssetId);
		}

		public void ClearMessages()
		{
			Messages.Clear();
		}

		private void AddAudioMessage(string role, string content, string audioData, IbmWatsonXChatInputAudioFormat audioFormat, string dataAssetId = null)
		{
			var msg = new IbmWatsonXChatInputMessage { Role = role };
			msg.Content.Add(new IbmWatsonXChatTextContent { Type = "text", Text = content });
			
			var audioContent = new IbmWatsonXChatInputAudioContent { Type = "input_audio", InputAudio = new IbmWatsonXChatInputAudio { Data = audioData, Format = audioFormat.ToString().ToLower() } };

			if (dataAssetId != null)
			{
				audioContent.DataAsset = new IbmWatsonXChatContentDataAsset { Id = dataAssetId };
			}

			msg.Content.Add(audioContent);

			Messages.Add(msg);
		}
		
		private void AddImageMessage(string role, string content, string imageUrl, string imageDetail = null, string dataAssetId = null)
		{
			var msg = new IbmWatsonXChatInputMessage { Role = role };
			msg.Content.Add(new IbmWatsonXChatTextContent { Type = "text", Text = content });

			var imageUrlContent = new IbmWatsonXChatImageUrlContent { Type = "image_url", ImageUrl = new IbmWatsonXChatImageUrl { Url = imageUrl, Detail = imageDetail } };
			
			if (dataAssetId != null)
			{
				imageUrlContent.DataAsset = new IbmWatsonXChatContentDataAsset { Id = dataAssetId };
			}

			msg.Content.Add(imageUrlContent);

			Messages.Add(msg);
		}

		private void AddVideoMessage(string role, string content, string videoUrl, string dataAssetId = null)
		{
			var msg = new IbmWatsonXChatInputMessage { Role = role };
			msg.Content.Add(new IbmWatsonXChatTextContent { Type = "text", Text = content });

			var videoUrlContent = new IbmWatsonXChatVideoUrlContent { Type = "video_url", VideoUrl = new IbmWatsonXChatVideoUrl { Url = videoUrl } };

			if (dataAssetId != null)
			{
				videoUrlContent.DataAsset = new IbmWatsonXChatContentDataAsset { Id = dataAssetId };
			}

			msg.Content.Add(videoUrlContent);

			Messages.Add(msg);
		}

		private void AddTextMessage(string role, string content)
		{
			var msg = new IbmWatsonXChatInputMessage { Role = role };
			msg.Content.Add(new IbmWatsonXChatTextContent { Type = "text", Text = content });
			Messages.Add(msg);
		}
	}
}
