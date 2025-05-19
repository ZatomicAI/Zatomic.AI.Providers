using System;
using Zatomic.AI.Providers.AI21Labs;
using Zatomic.AI.Providers.AmazonBedrock;
using Zatomic.AI.Providers.Anthropic;
using Zatomic.AI.Providers.AzureServerless;
using Zatomic.AI.Providers.Cohere;
using Zatomic.AI.Providers.DeepInfra;
using Zatomic.AI.Providers.Extensions;
using Zatomic.AI.Providers.FireworksAI;
using Zatomic.AI.Providers.HuggingFace;
using Zatomic.AI.Providers.Hyperbolic;
using Zatomic.AI.Providers.Lambda;
using Zatomic.AI.Providers.Meta;
using Zatomic.AI.Providers.Mistral;
using Zatomic.AI.Providers.TogetherAI;
using Zatomic.AI.Providers.xAI;

namespace Zatomic.AI.Providers.Exceptions
{
	public static class AIExceptionUtility
	{
		// NOTE: We clear the messages on all request objects to avoid data bloat in the thrown
		// exception and any unwanted logging of messages downstream (the cloning of the request
		// objects is to ensure thread safety). When the response JSON gets logged it will contain
		// the error response from the provider, not AI assistant responses.

		public static AIException BuildAI21LabsAIException(Exception ex, AI21LabsChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<AI21LabsChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("AI21 Labs", ex, clonedReq, responseJson);
		}

		public static AIException BuildAmazonBedrockAIException(Exception ex, AmazonBedrockChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<AmazonBedrockChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Amazon Bedrock", ex, clonedReq, responseJson);
		}

		public static AIException BuildAnthropicAIException(Exception ex, AnthropicChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<AnthropicChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Anthropic", ex, clonedReq, responseJson);
		}

		public static AIException BuildAzureServerlessAIException(Exception ex, AzureServerlessChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<AzureServerlessChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Azure Serverless", ex, clonedReq, responseJson);
		}

		public static AIException BuildCohereAIException(Exception ex, CohereChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<CohereChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Cohere", ex, clonedReq, responseJson);
		}

		public static AIException BuildDeepInfraAIException(Exception ex, DeepInfraChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<DeepInfraChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Deep Infra", ex, clonedReq, responseJson);
		}

		public static AIException BuildFireworksAIAIException(Exception ex, FireworksAIChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<FireworksAIChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Fireworks AI", ex, clonedReq, responseJson);
		}

		public static AIException BuildHuggingFaceAIException(Exception ex, HuggingFaceChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<HuggingFaceChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Hugging Face", ex, clonedReq, responseJson);
		}

		public static AIException BuildHyperbolicAIException(Exception ex, HyperbolicChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<HyperbolicChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Hyperbolic", ex, clonedReq, responseJson);
		}

		public static AIException BuildLambdaAIException(Exception ex, LambdaChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<LambdaChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Lambda", ex, clonedReq, responseJson);
		}

		public static AIException BuildMetaAIException(Exception ex, MetaChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<MetaChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Meta", ex, clonedReq, responseJson);
		}

		public static AIException BuildMistralAIException(Exception ex, MistralChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<MistralChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Mistral", ex, clonedReq, responseJson);
		}

		public static AIException BuildTogetherAIAIException(Exception ex, TogetherAIChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<TogetherAIChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("Together AI", ex, clonedReq, responseJson);
		}

		public static AIException BuildxAIAIException(Exception ex, xAIChatRequest request, string responseJson = null)
		{
			var clonedReq = request.Clone<xAIChatRequest>();
			clonedReq.Messages.Clear();

			return BuildAIException("xAI", ex, clonedReq, responseJson);
		}

		private static AIException BuildAIException(string provider, Exception ex, BaseRequest request, string responseJson = null)
		{
			var aiEx = new AIException(ex.Message) { Provider = provider, Request = request.Serialize() };

			if (!responseJson.IsNullOrEmpty())
			{
				aiEx.Response = responseJson;
			}

			return aiEx;
		}
	}
}
