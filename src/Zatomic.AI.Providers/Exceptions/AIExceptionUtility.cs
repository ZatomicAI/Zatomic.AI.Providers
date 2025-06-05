using System;
using Zatomic.AI.Providers.AI21Labs;
using Zatomic.AI.Providers.AmazonBedrock;
using Zatomic.AI.Providers.Anthropic;
using Zatomic.AI.Providers.AzureOpenAI;
using Zatomic.AI.Providers.AzureServerless;
using Zatomic.AI.Providers.Cohere;
using Zatomic.AI.Providers.DeepInfra;
using Zatomic.AI.Providers.Extensions;
using Zatomic.AI.Providers.FireworksAI;
using Zatomic.AI.Providers.GoogleGemini;
using Zatomic.AI.Providers.Groq;
using Zatomic.AI.Providers.HuggingFace;
using Zatomic.AI.Providers.Hyperbolic;
using Zatomic.AI.Providers.Lambda;
using Zatomic.AI.Providers.Meta;
using Zatomic.AI.Providers.Mistral;
using Zatomic.AI.Providers.OpenAI;
using Zatomic.AI.Providers.Perplexity;
using Zatomic.AI.Providers.TogetherAI;
using Zatomic.AI.Providers.xAI;

namespace Zatomic.AI.Providers.Exceptions
{
	public static class AIExceptionUtility
	{
		public static AIException BuildAI21LabsAIException(Exception ex, AI21LabsChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "AI21 Labs", request.Model, request, responseJson);
		}

		public static AIException BuildAmazonBedrockAIException(Exception ex, AmazonBedrockChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Amazon Bedrock", request.Model, request, responseJson);
		}

		public static AIException BuildAnthropicAIException(Exception ex, AnthropicChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Anthropic", request.Model, request, responseJson);
		}

		public static AIException BuildAzureOpenAIAIException(Exception ex, AzureOpenAIChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Azure OpenAI", request.Model, request, responseJson);
		}

		public static AIException BuildAzureServerlessAIException(Exception ex, AzureServerlessChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Azure Serverless", request.Model, request, responseJson);
		}

		public static AIException BuildCohereAIException(Exception ex, CohereChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Cohere", request.Model, request, responseJson);
		}

		public static AIException BuildDeepInfraAIException(Exception ex, DeepInfraChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Deep Infra", request.Model, request, responseJson);
		}

		public static AIException BuildFireworksAIAIException(Exception ex, FireworksAIChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Fireworks AI", request.Model, request, responseJson);
		}

		public static AIException BuildGoogleGeminiAIException(Exception ex, GoogleGeminiChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Google Gemini", request.Model, request, responseJson);
		}

		public static AIException BuildGroqAIException(Exception ex, GroqChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Groq", request.Model, request, responseJson);
		}

		public static AIException BuildHuggingFaceAIException(Exception ex, HuggingFaceChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Hugging Face", request.Model, request, responseJson);
		}

		public static AIException BuildHyperbolicAIException(Exception ex, HyperbolicChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Hyperbolic", request.Model, request, responseJson);
		}

		public static AIException BuildLambdaAIException(Exception ex, LambdaChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Lambda", request.Model, request, responseJson);
		}

		public static AIException BuildMetaAIException(Exception ex, MetaChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Meta", request.Model, request, responseJson);
		}

		public static AIException BuildMistralAIException(Exception ex, MistralChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Mistral", request.Model, request, responseJson);
		}

		public static AIException BuildOpenAIAIException(Exception ex, OpenAIChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "OpenAI", request.Model, request, responseJson);
		}

		public static AIException BuildPerplexityAIException(Exception ex, PerplexityChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Perplexity", request.Model, request, responseJson);
		}

		public static AIException BuildTogetherAIAIException(Exception ex, TogetherAIChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "Together AI", request.Model, request, responseJson);
		}

		public static AIException BuildxAIAIException(Exception ex, xAIChatRequest request, string responseJson = null)
		{
			return BuildAIException(ex, "xAI", request.Model, request, responseJson);
		}

		private static AIException BuildAIException<T>(Exception ex, string provider, string model, T request, string responseJson = null) where T : BaseRequest, IChatRequest
		{
			// We clear the messages on all request objects to avoid data bloat in the thrown exception
			// and any unwanted logging of messages downstream (the cloning of the request object is to
			// ensure thread safety). If/when the response JSON gets logged it will contain the error
			// response from the provider, not AI assistant responses.

			var clonedReq = request.Clone<T>();
			clonedReq.ClearMessages();

			var aiEx = new AIException(ex.Message)
			{
				Provider = provider,
				Model = model,
				Request = clonedReq.Serialize()
			};

			if (!responseJson.IsNullOrEmpty())
			{
				aiEx.Response = responseJson;
			}

			return aiEx;
		}
	}
}
