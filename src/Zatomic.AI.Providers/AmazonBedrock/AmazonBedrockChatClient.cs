using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Amazon;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using Zatomic.AI.Providers.Exceptions;
using Zatomic.AI.Providers.Extensions;

namespace Zatomic.AI.Providers.AmazonBedrock
{
	public class AmazonBedrockChatClient
	{
		private AmazonBedrockRuntimeClient _runtimeClient;

		public string AccessKey { get; set; }
		public string Region { get; set; }
		public string SecretKey { get; set; }

		public AmazonBedrockChatClient()
		{
		}

		public AmazonBedrockChatClient(string accessKey, string secretKey, string region) : this()
		{
			AccessKey = accessKey;
			SecretKey = secretKey;
			Region = region;
		}

		public async Task<AmazonBedrockChatResponse> ChatAsync(AmazonBedrockChatRequest request)
		{
			AmazonBedrockChatResponse response = null;

			try
			{
				InitializeRuntimeClient();

				var stopwatch = Stopwatch.StartNew();

				var converseReq = ConvertToConverseRequest(request);
				var converseRsp = await _runtimeClient.ConverseAsync(converseReq);
				response = ConvertToAmazonBedrockChatResponse(converseRsp);

				stopwatch.Stop();
				response.Duration = stopwatch.ToDurationInSeconds(2);
			}
			catch (Exception ex)
			{
				var aiEx = AIExceptionUtility.BuildAmazonBedrockAIException(ex, request);
				throw aiEx;
			}

			return response;
		}

		public async IAsyncEnumerable<AIStreamResult> ChatStreamAsync(AmazonBedrockChatRequest request)
		{
			var converseReq = ConvertToConverseRequest(request);
			var converseStreamReq = new ConverseStreamRequest
			{
				ModelId = converseReq.ModelId,
				Messages = converseReq.Messages,
				InferenceConfig = converseReq.InferenceConfig,
				System = converseReq.System
			};

			ConverseStreamResponse converseStreamRsp = null;

			try
			{
				// This is wrapped in a try-catch in case an error occurs at the start
				converseStreamRsp = await _runtimeClient.ConverseStreamAsync(converseStreamReq);
			}
			catch (Exception ex)
			{
				var aiEx = AIExceptionUtility.BuildAmazonBedrockAIException(ex, request);
				throw aiEx;
			}

			var stopwatch = Stopwatch.StartNew();

			foreach (var item in converseStreamRsp.Stream)
			{
				AIStreamResult result = null;

				try
				{
					// These are wrapped in a try-catch in case an error occurs mid-stream

					if (item is ContentBlockDeltaEvent deltaEvent)
					{
						result = new AIStreamResult { Chunk = deltaEvent.Delta.Text };
					}

					if (item is ConverseStreamMetadataEvent metaEvent)
					{
						stopwatch.Stop();

						result = new AIStreamResult
						{
							InputTokens = metaEvent.Usage.InputTokens,
							OutputTokens = metaEvent.Usage.OutputTokens,
							TotalTokens = metaEvent.Usage.TotalTokens,
							Duration = stopwatch.ToDurationInSeconds(2)
						};
					}
				}
				catch (Exception ex)
				{
					var aiEx = AIExceptionUtility.BuildAmazonBedrockAIException(ex, request);
					throw aiEx;
				}

				if (result != null)
				{
					yield return result;
				}
			}
		}

		private void InitializeRuntimeClient()
		{
			var bedrockConfig = new AmazonBedrockRuntimeConfig { RegionEndpoint = RegionEndpoint.GetBySystemName(Region) };
			_runtimeClient = new AmazonBedrockRuntimeClient(AccessKey, SecretKey, bedrockConfig);
		}

		private ConverseRequest ConvertToConverseRequest(AmazonBedrockChatRequest request)
		{
			var converseReq = new ConverseRequest { ModelId = request.Model };

			converseReq.Messages = new List<Message>();
			foreach (var m in request.Messages)
			{
				var msg = new Message { Role = m.Role };
				msg.Content = new List<ContentBlock>();

				foreach (var c in m.Content)
				{
					msg.Content.Add(new ContentBlock { Text = c.Text });
				}

				converseReq.Messages.Add(msg);
			}

			if (!request.System.IsNullOrEmpty())
			{
				converseReq.System = new List<SystemContentBlock>();
				converseReq.System.Add(new SystemContentBlock { Text = request.System });
			}

			if (request.MaxTokens.HasValue ||
			   (request.StopSequences != null && request.StopSequences.Count > 0) ||
			   request.Temperature.HasValue ||
			   request.TopP.HasValue)
			{
				converseReq.InferenceConfig = new InferenceConfiguration();

				if (request.MaxTokens.HasValue)
				{
					converseReq.InferenceConfig.MaxTokens = request.MaxTokens.Value;
				}

				if (request.StopSequences != null && request.StopSequences.Count > 0)
				{
					converseReq.InferenceConfig.StopSequences = new List<string>(request.StopSequences);
					converseReq.InferenceConfig.StopSequences.AddRange(request.StopSequences);
				}

				if (request.Temperature.HasValue)
				{
					converseReq.InferenceConfig.Temperature = request.Temperature.Value;
				}

				if (request.TopP.HasValue)
				{
					converseReq.InferenceConfig.TopP = request.TopP.Value;
				}
			}

			return converseReq;
		}

		private AmazonBedrockChatResponse ConvertToAmazonBedrockChatResponse(ConverseResponse converseResponse)
		{
			var response = new AmazonBedrockChatResponse { StopReason = converseResponse.StopReason };

			if (converseResponse.Output != null)
			{
				response.Output = new AmazonBedrockChatOutput();

				if (converseResponse.Output.Message != null)
				{
					response.Output.Message = new AmazonBedrockChatMessage
					{
						Role = converseResponse.Output.Message.Role,
						Content = new List<AmazonBedrockChatContent>()
					};

					foreach (var c in converseResponse.Output.Message.Content)
					{
						response.Output.Message.Content.Add(new AmazonBedrockChatContent { Text = c.Text });
					}
				}
			}

			if (converseResponse.Usage != null)
			{
				response.Usage = new AmazonBedrockChatUsage
				{
					InputTokens = converseResponse.Usage.InputTokens.Value,
					OutputTokens = converseResponse.Usage.OutputTokens.Value,
					TotalTokens = converseResponse.Usage.TotalTokens.Value
				};
			}

			return response;
		}
	}
}
